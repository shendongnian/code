        public void Update(string className)
        {
            Type t = Type.GetType(className), s = typeof(IService<>);
            var g = s.MakeGenericType(t);
            var something = UnityContainer.Resolve(g);
            //...
