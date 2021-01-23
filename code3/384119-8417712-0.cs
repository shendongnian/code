		public void CreateAttributeMapping(string fieldNameFrom, string entityNameFrom, string fieldNameTo, string entityNameTo)
		{
			var entityMap = Retrieve("entitymap", new List<FilterCriteria> { new FilterCriteria("targetentityname", entityNameTo), new FilterCriteria("sourceentityname", entityNameFrom) }, null);
			var entityMapId = new v4.Sdk.Lookup();
			entityMapId.name = entityMap.GetKeyName();
			entityMapId.Value = entityMap.GetKeyValue();
			var attributeMap = new v4.SdkTypeProxy.attributemap();
			attributeMap.entitymapid = entityMapId;
			attributeMap.sourceattributename = fieldNameTo;
			attributeMap.targetattributename = fieldNameFrom;
			var targetAttributeMap = new v4.SdkTypeProxy.TargetCreateAttributeMap();
			targetAttributeMap.AttributeMap = attributeMap;
			var attributeMapCreateRequest = new v4.SdkTypeProxy.CreateRequest();
			attributeMapCreateRequest.Target = targetAttributeMap;
			var response = this.CrmService.Execute(attributeMapCreateRequest);
