        {
            Dictionary<string, bool> tempkvp = new Dictionary<string, bool>();
            List<T> uniques = new List<T>();
            List<string> columns = collection.FirstOrDefault().GetType().GetProperties().ToList().ConvertAll<string>(x => x.Name.ToLower());
            var property = attribute != null && collection.Count() > 0 && columns.Contains(attribute.ToLower()) ? ViewModelHelpers.GetProperty(collection.FirstOrDefault(), attribute) : null;
            if (property != null)
            {
                foreach (T obj in collection)
                {
                    string value = property.GetValue(obj, null).ToString();
                    if (!(tempkvp.ContainsKey(value)))
                    {
                        tempkvp.Add(value, true);
                        uniques.Add(obj);
                    }
                }
            }
            return uniques;
        }
