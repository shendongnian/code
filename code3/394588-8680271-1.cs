        public void Update(string className)
        {
            var targetType = Type.GetType(className);
            var serviceType = typeof(IService<>);
            var genericParam = serviceType.MakeGenericType(targetType);
            var unityType = typeof(UnityContainer);
            var resolve = unityType.GetMethod("Resolve");
            var targetMethod = resolve.MakeGenericMethod(genericParam);
            var something = targetMethod.Invoke(null, new[] { genericParam });
            //...
