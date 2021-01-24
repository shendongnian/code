    static void Main()
        {
            //The namespace of your ProductClass
            string NameSpace = "SomeNameSpace.SomeSecondaryNameSpace";
            Product toSave = new Product(Name:"myProduct");
            //Load your assembly from where it is, doesn't matter
            Assembly assembly = Assembly.LoadFile("Some Assembly Path");
            //Load your type with the namespace, as you already do
            Type productClass = assembly.GetType($"{NameSpace}.ProductClass");
            //Type.GetMethod returns MethodInfo object and not MethodBase
            MethodInfo saveMethod = productClass.GetMethod("Save");
            //Create an instance of your ProductClass class
            object instance = Activator.CreateInstance(productClass);
            //Invoke your Save method with your instance and your product to save
            saveMethod.Invoke(instance, new object[] { toSave });
            Console.ReadKey();
        }
