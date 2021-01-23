		private void Map()
		{
            _mapper.AddMappings(MappingAssembly.GetExportedTypes());
            Configure.AddDeserializedMapping(_mapper.CompileMappingForAllExplicitlyAddedEntities(), "MyWholeDomain"); 
		}
