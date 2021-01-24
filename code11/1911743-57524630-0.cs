        private static IEnumerable<string> GetModifiedProperties(DbEntityEntry dbEntityEntry)
        {
            foreach (var propertyName in dbEntityEntry.OriginalValues.PropertyNames)
            {
                var originalValue = dbEntityEntry.OriginalValues[propertyName];
                var currentValue = dbEntityEntry.CurrentValues[propertyName];
                if (!Equals(originalValue, currentValue))
                {
                    yield return propertyName;
                }
            }
        }
