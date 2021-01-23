            private static bool _initialized;
            public static IEnumerable<T> Values
            {
                get
                {
                    if (_initialized)
                    {
                        return nameRegistry.Values;
                    }
                    var aField = typeof(T).GetFields(
                                                BindingFlags.Public | BindingFlags.Static)
                                            .FirstOrDefault();
                    if (aField != null)
                        aField.GetValue(null);
                    _initialized = true;
                    return nameRegistry.Values;
                }
            }
