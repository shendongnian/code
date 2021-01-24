            var data2 = new SampleTemperatureDataVector[]
            {
                new SampleTemperatureDataVector
                {
                    Date = DateTime.UtcNow, 
                    Temperature = new float[] {1.2f, 3.4f, 5.6f}
                },
                 new SampleTemperatureDataVector
                {
                    Date = DateTime.UtcNow,
                    Temperature = new float[] {1.2f, 3.4f, 5.6f}
                },
            };
            int featureDimension = 3;
            var autoSchema = SchemaDefinition.Create(typeof(SampleTemperatureDataVector));
            var featureColumn = autoSchema[1];
            var itemType = ((VectorDataViewType)featureColumn.ColumnType).ItemType;
            featureColumn.ColumnType = new VectorDataViewType(itemType, featureDimension);
            IDataView data3 = mlContext.Data.LoadFromEnumerable(data2, autoSchema);
