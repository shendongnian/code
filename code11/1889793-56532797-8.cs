	private IReadOnlyList<DynamicProperty> CombineProperties(DynamicData deserializedRawData)
	{
		return (from formGroupProp in deserializedRawData.GetType().GetProperties()
				let formGroup = formGroupProp.GetValue(deserializedRawData)
				let formGroupType = FormHelper.GetFormGroupType(formGroupProp.Name)
				let properties = formGroupProp.GetType().GetProperty("Properties").GetValue(formGroup)
				from dProp in properties.GetType().GetProperties()
				let fieldInfo = dProp.GetValue(properties) as DynamicDataFieldInfo
				where fieldInfo is DynamicDataFieldInfo
				select new DynamicProperty { DynamicDataFieldInfo = fieldInfo, GroupType = formGroupType }).ToList()
	}
