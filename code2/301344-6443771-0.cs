            List<string> _propertiesToInclude = new List<string>();
            Type t;
            var props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.IsClass)
                    foreach (var subprop in prop.PropertyType.GetProperties())
                        _propertiesToInclude.Add(string.Format("{0}.{1}", prop.Name, subprop.Name));
                else
                    _propertiesToInclude.Add(prop.Name);
            }
