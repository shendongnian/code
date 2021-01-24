     // Get a small dataset as an IEnumerable and convert it to an IDataView.
            var samples = new List<InputData>
            {
                new InputData { Age = 26 },
                new InputData { Age = 35 },
                new InputData { Age = 34 },
                new InputData { Age = 28 },
            };
            var data = mlContext.Data.LoadFromEnumerable(samples);
            // We define the custom mapping between input and output rows that will be applied by the transformation.
            Action<InputData, CustomMappingOutput > mapping =
                (input, output) => output.IsUnderThirty = input.Age < 30;
