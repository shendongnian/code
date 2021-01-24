            var properties = typeof(TestData).GetProperties();
            foreach (KeyValuePair<string, TestData> entry in data)
            {
                foreach (var propertyInfo in properties)
                {
                    var X = propertyInfo.GetValue(entry.Value);
                }
            }
