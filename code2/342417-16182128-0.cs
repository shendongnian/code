        public static System.Reflection.MethodInfo ExtensionOverrider(this Object obj, System.Reflection.MethodInfo method )
        {
            return obj.GetType().GetMethods().Where(
                x => x.Name == method.Name &&
                x.GetParameters().Select(z => z.ParameterType).SequenceEqual(method.GetParameters().Skip(1).Select(w => w.ParameterType))).FirstOrDefault(); 
        }
        public static void foo(this ISomething graphic)
        {
            var Method = graphic.ExtensionOverrider(System.Reflection.MethodBase.GetCurrentMethod());                
            if( Method != null)
                Method.Invoke(graphic, new Object[0]{});
        }
