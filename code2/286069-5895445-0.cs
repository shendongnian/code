            var typeBasedFunctionDictionary = new Dictionary<Type, Action>();
            typeBasedFunctionDictionary.Add(typeof(string), () => Console.WriteLine("string..."));
            typeBasedFunctionDictionary.Add(typeof(decimal), () => Console.WriteLine("decimal..."));
            typeBasedFunctionDictionary.Add(typeof(int), () => Console.WriteLine("int..."));
            //if (!typeBasedFunctionDictionary.ContainsKey(typeof(object)))
            //{
            //    throw (new InvalidOperationException("Type not supported..."));
            //}
            typeBasedFunctionDictionary["foo".GetType()]();
            typeBasedFunctionDictionary[10.2m.GetType()]();
            typeBasedFunctionDictionary[10.GetType()]();
