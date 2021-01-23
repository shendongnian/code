    class ClassName
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    
        public void Print()
        {
            foreach (PropertyInfo prop in typeof(ClassName).GetProperties())
            {
                MethodInfo getter = prop.GetGetMethod();
                object value = getter.Invoke(this, new object[] { }); //invoke the Method with the current object, and we pass in no parameters
                Console.WriteLine("{0} = {1}", prop.Name, value);
            }
        }
    }
