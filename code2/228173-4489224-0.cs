        public class PropertyWrapper<T>
        {
            private Dictionary<string, MethodBase> _getters = new Dictionary<string, MethodBase>();
            public PropertyWrapper()
            {
                foreach (var item in typeof(T).GetProperties())
                {
                    if (!item.CanRead)
                        continue;
                    _getters.Add(item.Name, item.GetGetMethod());
                }
            }
            public string GetValue(T instance, string name)
            {
                MethodBase getter;
                if (_getters.TryGetValue(name, out getter))
                    return getter.Invoke(instance, null).ToString();
                return string.Empty;
            }
        }
