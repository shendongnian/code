     public class InstanceCreator
    {
        /// <summary>
        /// Get the Instance from a fully qualified Name
        /// </summary>
        /// <param name="strFullyQualifiedName"></param>
        /// <returns></returns>
        public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }
        /// <summary>
        /// Invoking the Method By Passing the Instance as well as the Method Name
        /// </summary>
        /// <param name="Instance">Instance Object</param>
        /// <param name="MethodName">Method Name</param>
        /// <returns></returns>
        public object InvokeMethod(object Instance, String MethodName) {
            Type t = Instance.GetType();
            MethodInfo method = t.GetMethod(MethodName);
            return method.Invoke(Instance, null);
        }
    }
    public class SampleClass {
        public bool doAction() {
            return true;
        }
    }
    public class TestClass {
        public Dictionary<String, String> FunctionList = new Dictionary<string, string>();
        public TestClass() {
            
            this.Verify();
        }
        public void Verify() {
            String fullyQualifiedName = typeof(SampleClass).AssemblyQualifiedName;
            FunctionList.Add("SAMPLE", $"{fullyQualifiedName}#doAction");
            InstanceCreator Creator = new InstanceCreator();
            String[] FunctionMapping = FunctionList["SAMPLE"].Split('#');
            object Test = Creator.GetInstance(FunctionMapping[0]);
            bool Result = (bool)Creator.InvokeMethod(Test, FunctionMapping[1]);
        }
    }
