	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Text.RegularExpressions;
	using System.Web.Mvc;
	namespace DabTrial.Infrastructure.Validation
	{
		[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
		public class RegexCountAttribute : MultipleValidationAttribute
		{
			# region members
			private string _defaultErrorMessageFormatString;
			protected readonly string _regexStr;
			protected readonly RegexOptions _regexOpt;
			private int _minimumCount=0;
			private int _maximumCount=int.MaxValue;
			#endregion
			#region properties
			public int MinimumCount 
			{
				get { return _minimumCount; } 
				set 
				{
					if (value < 0) { throw new ArgumentOutOfRangeException(); }
					_minimumCount = value; 
				} 
			}
			public int MaximumCount
			{
				get { return _maximumCount; }
				set 
				{
					if (value < 0) { throw new ArgumentOutOfRangeException(); }
					_maximumCount = value; 
				}
			}
			private string DefaultErrorMessageFormatString
			{
				get
				{
					if (_defaultErrorMessageFormatString == null)
					{
						_defaultErrorMessageFormatString = string.Format(
							"{{0}} requires a {0}{1}{2} match(es) to regex {3}", 
							MinimumCount>0?"minimum of "+ MinimumCount:"",
							MinimumCount > 0 && MaximumCount< int.MaxValue? " and " : "",
							MaximumCount<int.MaxValue?"maximum of "+ MaximumCount:"",
							_regexStr);
					}
					return _defaultErrorMessageFormatString;
				}
				set
				{
					_defaultErrorMessageFormatString = value;
				}
				
			}
			#endregion
			#region instantiation
			public RegexCountAttribute(string regEx, string defaultErrorMessageFormatString = null, RegexOptions regexOpt = RegexOptions.None)
			{
	#if debug
				if (minimumCount < 0) { throw new ArgumentException("the minimum value must be non-negative"); }
	#endif
				_regexStr = regEx;
				DefaultErrorMessageFormatString = defaultErrorMessageFormatString;
				_regexOpt = regexOpt;
			}
			#endregion
			#region methods
			protected override ValidationResult IsValid(object value,
														ValidationContext validationContext)
			{
				var instr = (string)value;
				int matchCount = 0;
				if (MinimumCount > 0 && instr != null)
				{
					Match match = new Regex(_regexStr,_regexOpt).Match(instr);
					while (match.Success && ++matchCount < MinimumCount)
					{
					   match = match.NextMatch();
					}
					if (MaximumCount != int.MaxValue)
					{
						while (match.Success && ++matchCount <= MaximumCount)
						{
							match = match.NextMatch();
						}
					}
				}
				if (matchCount >= MinimumCount && matchCount <=MaximumCount)
				{
					return ValidationResult.Success;
				}
				string errorMessage = GetErrorMessage(validationContext.DisplayName);
				return new ValidationResult(errorMessage);
			}
			protected string GetErrorMessage(string displayName)
			{
				return ErrorMessage ?? string.Format(DefaultErrorMessageFormatString,
					displayName,
					MinimumCount);
			}
			private bool HasFlag(RegexOptions options, RegexOptions flag)
			{
				return ((options & flag) == flag);
			}
			private string RegexpModifier
			{
				get 
				{
					string options = string.Empty;
					if (HasFlag(_regexOpt, RegexOptions.IgnoreCase)) { options += 'i'; }
					if (HasFlag(_regexOpt, RegexOptions.Multiline)) { options += 'm'; }
					return options;
				}
			}
			public override IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata)
			{
				var returnVal = new ModelClientValidationRule {
					ErrorMessage = GetErrorMessage(metadata.DisplayName),
					ValidationType = "regexcount",
				};
				returnVal.ValidationParameters.Add("min",MinimumCount);
				returnVal.ValidationParameters.Add("max",MaximumCount);
				returnVal.ValidationParameters.Add("regex",_regexStr);
				returnVal.ValidationParameters.Add("regexopt", RegexpModifier);
				yield return returnVal;
			}
			#endregion
		}
		public class MinNonAlphanum : RegexCountAttribute
		{
			public MinNonAlphanum(int minimum) : base("[^0-9a-zA-Z]", GetDefaultErrorMessageFormatString(minimum)) 
			{
				this.MinimumCount = minimum;
			}
			private static string GetDefaultErrorMessageFormatString(int min)
			{
				if (min == 1)
				{
					return "{0} requires a minimum of {1} character NOT be a letter OR number";
				}
				return "{0} requires a minimum of {1} characters NOT be a letter OR number";
			}
		}
		public class MinDigits : RegexCountAttribute
		{
			public MinDigits(int minimum) : base(@"\d", GetDefaultErrorMessageFormatString(minimum)) 
			{
				this.MinimumCount = minimum;
			}
			private static string GetDefaultErrorMessageFormatString(int min)
			{
				if (min == 1)
				{
					return "{0} requires a minimum of {1} character is a number";
				}
				return "{0} requires a minimum of {1} characters are numbers";
			}
		}
	}
