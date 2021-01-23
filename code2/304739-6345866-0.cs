    foreach (PropertyInfo pi in tc.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic ).ToArray() )
                {
                    if (pi.PropertyType == typeof(string))
                    {
                        pi.SetValue(tc, string.Empty, null);
                    }
                }
