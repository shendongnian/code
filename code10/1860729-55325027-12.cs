    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Extensions.Hosting;
    
    namespace NoSuchCompany.QualityTools.Service.Automation.Hosting
    {
        #region Class
    
        /// <summary>
        /// Builds a <see cref="IHost"/> instance that can be used to inject parameters into a Function.
        /// </summary>
        /// <remarks>
        /// To use it for integration tests, first build a Startup class or one derived from it that contains
        /// mock instances of the services to inject.
        ///
        /// public class Startup
        /// {
        ///     public override void Configure(IFunctionsHostBuilder functionsHostBuilder)
        ///     {
        ///          ConfigureEmailService(functionsHostBuilder.Services);
        ///     }      
        ///
        /// 
        ///     protected virtual void ConfigureSomeService(IServiceCollection serviceCollection)
        ///     {
        ///        //  Inject a concrete service.
        ///        serviceCollection.AddTransient<ISomeService, SomeService>();
        ///     }
        /// }
        /// 
        /// public sealed class TestStartup : Startup
        /// {
        ///     protected override void ConfigureSomeService(IServiceCollection serviceCollection)
        ///     {
        ///        //  Inject a mock service.
        ///        serviceCollection.AddTransient<ISomeService, MockOfSomeService>();
        ///     }
        /// }
        ///
        /// Then, the helper can be called with like this:
        ///
        /// var startup = new TestStartup();
        /// 
        /// var myAzureFunctionToTest = HostHelper.Instantiate<AnAzureFunction>(startup);
        /// 
        /// </remarks>
        [ExcludeFromCodeCoverage]
        public static class HostHelper
        {
            #region Public Methods
    
            /// <summary>
            /// Builds an instance of the specified <typeparamref name="TFunctionType"/>
            /// with the services defined in the <paramref name="startup"/> instance.
            /// </summary>
            /// <typeparam name="TFunctionType"></typeparam>
            /// <param name="startup"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if:
            /// - The <paramref name="startup" /> instance is not specified.
            /// </exception>
            public static TFunctionType Instantiate<TFunctionType>(Startup startup)
            {
                if(startup is null)
                    throw new ArgumentNullException($"The parameter {nameof(startup)} instance is not specified.");
                    
                IHost host = new HostBuilder().ConfigureWebJobs(startup.Configure).Build();
    
                return Instantiate<TFunctionType>(host);
            }
    
            #endregion
    
            #region Private Methods
    
            /// <summary>
            /// Instantiates the specified <typeparamref name="TFunctionType"></typeparamref>.
            /// </summary>
            /// <typeparam name="TFunctionType"></typeparam>
            /// <param name="host"></param>
            /// <returns></returns>
            private static TFunctionType Instantiate<TFunctionType>(IHost host)
            {
                Type type = typeof(TFunctionType);
    
                ConstructorInfo constructorInfo = type.GetConstructors().FirstOrDefault();
    
                ParameterInfo[] parametersInfo = constructorInfo.GetParameters();
    
                object[] parameters = LookupServiceInstances(host, parametersInfo);
    
                return (TFunctionType) Activator.CreateInstance(type, parameters);
            }
    
            /// <summary>
            /// Gets all the parameters instances from the host's services.
            /// </summary>
            /// <param name="host"></param>
            /// <param name="parametersInfo"></param>
            /// <returns></returns>
            private static object[] LookupServiceInstances(IHost host, IReadOnlyList<ParameterInfo> parametersInfo)
            {
                return parametersInfo.Select(parameter => host.Services.GetService(parameter.ParameterType))
                                     .ToArray();
            }
    
            #endregion
        }
    
        #endregion
    }
