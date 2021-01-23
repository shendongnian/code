        private static Dictionary<String, Type> objects = new Dictionary<string, Type>();
        static MyFactory()
        {
            // Scan the assembly
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                MyAttribute[] frameAttributes =
                    type.GetCustomAttributes(typeof (MyAttribute), false) as MyAttribute[];
                foreach (MyAttribute myAttribute in frameAttributes)
                {
                    objects.Add(myAttribute.SomeKey, type);
                }
            }
        }
