    public static void PopStack(Stack stObj)
        {
            foreach (var st in stObj.ToArray())
            {
                var obj= stObj.Pop();
                Console.WriteLine(count);
                Console.WriteLine(obj);
               
            }
    
            Console.WriteLine("\tCount:    {0}", stObj.Count);
    
        }
