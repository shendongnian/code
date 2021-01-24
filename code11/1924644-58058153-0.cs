            var propertyCollection = typeof(Number).GetProperties();
            foreach (var item in propertyCollection)
            {
                number[item.Name.ToString()] = Int32.Parse(item.GetValue(obj));
            }
