	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Web.Mvc;
	using Newtonsoft.Json;
	namespace DabTrial.Infrastructure.Validation
	{
		[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
		public abstract class MultipleValidationAttribute : ValidationAttribute, IMetadataAware
		{
			private class Validation
			{
				public ICollection<string> ErrorMessage { get; set; }
				public IDictionary<string, ICollection<object>> Attributes { get; set; }
			}
			private object _typeId = new object();
			public const string attributeName = "multipleValidations";
			public MultipleValidationAttribute()
			{
			}
			public override object TypeId
			{
				get
				{
					return this._typeId;
				}
			}
			public void OnMetadataCreated(ModelMetadata metadata)
			{
				Dictionary<string, Validation> allMultis;
				if (metadata.AdditionalValues.ContainsKey(attributeName))
				{
					allMultis = (Dictionary<string, Validation>)metadata.AdditionalValues[attributeName];
				}
				else
				{
					allMultis = new Dictionary<string, Validation>();
					metadata.AdditionalValues.Add(attributeName, allMultis);
				}
				foreach (var result in GetClientValidationRules(metadata))
				{
					if (allMultis.ContainsKey(result.ValidationType))
					{
						var thisMulti = allMultis[result.ValidationType];
						thisMulti.ErrorMessage.Add(result.ErrorMessage);
						foreach (var attr in result.ValidationParameters)
						{
							thisMulti.Attributes[attr.Key].Add(attr.Value);
						}
					}
					else
					{
						var thisMulti = new Validation
						{
							ErrorMessage = new List<string>(),
							Attributes = new Dictionary<string, ICollection<object>>()
						};
						allMultis.Add(result.ValidationType, thisMulti);
						thisMulti.ErrorMessage.Add(result.ErrorMessage);
						foreach (var attr in result.ValidationParameters)
						{
							var newList = new List<object>();
							newList.Add(attr.Value);
							thisMulti.Attributes.Add(attr.Key, newList);
						}
					}
				}
			}
			public static IEnumerable<KeyValuePair<string, object>> GetAttributes(ModelMetadata metadata)
			{
				if (!metadata.AdditionalValues.ContainsKey(attributeName))
				{
					return null;
				}
				var returnVar = new List<KeyValuePair<string, object>>();
				returnVar.Add(new KeyValuePair<string,object>("data-val", true));
				var allMultis = (Dictionary<string, Validation>)metadata.AdditionalValues[attributeName];
				foreach (var multi in allMultis)
				{
					string valName = "data-val-" + multi.Key;
					returnVar.Add(new KeyValuePair<string,object>(valName, JsonConvert.SerializeObject(multi.Value.ErrorMessage)));
					returnVar.AddRange(multi.Value.Attributes.Select(a=>new KeyValuePair<string,object>(valName + '-' + a.Key, JsonConvert.SerializeObject(a.Value))));
				}
				return returnVar;
			}
			public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
																				   ControllerContext context)
			{
				throw new NotImplementedException("This function must be overriden");
			}
			public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata)
			{
				return GetClientValidationRules(metadata, null);
			}
		}
	}
