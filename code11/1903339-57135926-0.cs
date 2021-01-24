c#
using System.ComponentModel.DataAnnotations;
using SettingValidation.Traits;
namespace Configs
{
	public class JwtConfig : IValidatable<JwtConfig>
	{
		[Required, StringLength(256, MinimumLength = 32)]
		public string Key { get; set; }
		[Required]
		public string Issuer { get; set; } = string.Empty;
		[Required]
		public string Audience { get; set; } = "*";
		[Range(1, 30)]
		public int ExpireDays { get; set; } = 30;
	}
}
This is the "trait interface" that adds the validation capability (in c# 8 this could be changed to an interface with default methods)
_SettingValidation/Traits/IValidatable.cs_
c#
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Logging;
namespace SettingValidation.Traits
{
	public interface IValidatable
	{
	}
	public interface IValidatable<T> : IValidatable
	{
	}
	public static class IValidatableTrait
	{
		public static void Validate(this IValidatable @this, ILogger logger)
		{
			var validation = new List<ValidationResult>();
			if (Validator.TryValidateObject(@this, new ValidationContext(@this), validation, validateAllProperties: true))
			{
				logger.LogInformation($"{@this} Correctly validated.");
			}
			else
			{
				logger.LogError($"{@this} Failed validation.{Environment.NewLine}{validation.Aggregate(new System.Text.StringBuilder(), (sb, vr) => sb.AppendLine(vr.ErrorMessage))}");
				throw new ValidationException();
			}
		}
	}
}
Once you have this, you need to add a startup filter:
_SettingValidation/Filters/SettingValidationStartupFilter.cs_
c#
﻿using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SettingValidation.Traits;
namespace SettingValidation.Filters
{
	public class SettingValidationStartupFilter
	{
		public SettingValidationStartupFilter(IEnumerable<IValidatable> validatables, ILogger<SettingValidationStartupFilter> logger)
		{
			foreach (var validatable in validatables)
			{
				validatable.Validate(logger);
			}
		}
	}
}
It's convention to add an extension method:
_SettingValidation/Extensions/IServiceCollectionExtensions.cs_
c#
﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SettingValidation.Filters;
using SettingValidation.Traits;
namespace SettingValidation.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection UseConfigurationValidation(this IServiceCollection services)
		{
			services.AddSingleton<SettingValidationStartupFilter>();
			using (var scope = services.BuildServiceProvider().CreateScope())
			{
				// Do not remove this call.
				// ReSharper disable once UnusedVariable
				var validatorFilter = scope.ServiceProvider.GetRequiredService<SettingValidationStartupFilter>();
			}
			return services;
		}
		//
		// Summary:
		//     Registers a configuration instance which TOptions will bind against.
		//
		// Parameters:
		//   services:
		//     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the services
		//     to.
		//
		//   config:
		//     The configuration being bound.
		//
		// Type parameters:
		//   TOptions:
		//     The type of options being configured.
		//
		// Returns:
		//     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
		//     calls can be chained.
		public static IServiceCollection ConfigureAndValidate<T>(this IServiceCollection services, IConfiguration config)
			where T : class, IValidatable<T>, new()
		{
			services.Configure<T>(config);
			services.AddSingleton<IValidatable>(r => r.GetRequiredService<IOptions<T>>().Value);
			return services;
		}
	}
}
Finally enable the usage of the startup filter
_Startup.cs_
c#
public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		...
		services.UseConfigurationValidation();
		...
	}
}
I remember basing this code from some blog post in the internet I couldn't find right now, maybe it's the same you found, even if you dont use this solution, try refactoring what you did into a different project, so it can be reused in other ASP.NET Core solutions that you have.
Have a nice day.
