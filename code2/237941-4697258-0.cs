    class Program
    {
        static void Main(string[] args)
        {
            var dataTypes = "System.UInt32, System.String, System.String, System.UInt32";
    
            //out or in parameters of your function.   
            char[] charSeparators = new char[] { ',', ' ' };
            string[] types = dataTypes.Split(charSeparators,
                                StringSplitOptions.RemoveEmptyEntries);
    
            // create a list of data types for each argument
            List<Type> listTypes = new List<Type>();
            foreach (string t in types)
            {
                listTypes.Add(Type.GetType(t));
            }
            // convert the list to an array
            Type[] paramTypes = listTypes.ToArray<Type>();
        }
    }
