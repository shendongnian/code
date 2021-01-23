        private MethodInfo cachedMethod = null;
        private void AddGenericObject(IEnumerable list)
        {
            if (cachedMethod == null)
            {
                // Find Add Method
                var addMethod = this.GetType()
                     .GetMethod("AddObject", BindingFlags.NonPublic | BindingFlags.Instance);
                // Created Generic Add Method
                var genericType = list.GetType().GetGenericArguments()[0];
                cachedMethod = addMethod.MakeGenericMethod(genericType);
            }
            
            // Invoke Method
            cachedMethod.Invoke(this, new object[] { list });
        }
