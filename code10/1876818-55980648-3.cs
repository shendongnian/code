    UserDetails yourObject = new UserDetails();
                yourObject.Test1 = new List<Test> { new Test() };
    
                var result = typeof(UserDetails).GetProperties()
                    .Select(prop => prop)
                    .Where(property =>
                    {
                        if (property.PropertyType == typeof(List<Test>))
                        {
                            var value = (List<Test>)property.GetValue(yourObject, null);
                            return value == null || value.Count == 0;
                        }
    
                        return false;
                    }).ToList(); // this will return 1 because 1 property has count > 1
