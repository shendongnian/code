    class A
    {
        public void MyMethod(int num, string aString)
        { 
            ParameterInfo[] parameters = typeof(A).GetMethod("MyMethod", BindingFlags.Public|BindingFlags.Instance).GetParameters();
            string secondParameterName = parameters[1].Name;   //you will get aString
        }
    }
