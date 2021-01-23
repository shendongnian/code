            Assembly assembly = Assembly.Load("MyProject.Components");
            Type dllType = assembly.GetType("MynameSpace.MyClass");
            if (dllType != null)
            {
                IMyInterface instance = Activator.CreateInstance(dllType) as IMyInterface;
                if (instance != null) // check if this object actually implements the IMyInterface interface
                {
                    instance.MyFunction(objTest);
                }
            }
