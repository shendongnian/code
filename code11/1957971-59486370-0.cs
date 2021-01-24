     // object here referres to any object you are inspecting
            var props = Object.GetType().GetProperties();
            foreach (var p in props)
            {
                if (p.PropertyType.IsValueType)
                {
                    // This is not a class
                }
            }
