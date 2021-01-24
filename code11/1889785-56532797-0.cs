	private IReadOnlyList<DynamicProperty> CombineProperties(DynamicData deserializedRawData)
	{
		List<DynamicProperty> combinedDynamicProperties = new List<DynamicProperty>();
		// dynamic data
		foreach (PropertyInfo propertiyofDynamicData in deserializedRawData.GetType()
			.GetProperties())
		{
			object formGroup = propertiyofDynamicData.GetValue(deserializedRawData);
		
			// dynamic data lower level
			PropertyInfo propertyOfDynamicDataMember = propertiyofDynamicData.GetType().GetProperty("Properties");
			object propertiesGroup = propertyOfDynamicDataMember.GetValue(formGroup);
			
			foreach (PropertyInfo propertyOfFieldInfo in propertyOfDynamicDataMember.GetType()
				.GetProperties())
			{
				if (propertyOfFieldInfo.GetValue(propertiesGroup) is DynamicDataFieldInfo dynamicDataFieldInfo)
					combinedDynamicProperties.Add(new DynamicProperty {DynamicDataFieldInfo = dynamicDataFieldInfo, GroupType = FormHelper.GetFormGroupType(propertiyofDynamicData.Name)});
			}
		}
		return combinedDynamicProperties;
	}
