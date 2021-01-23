    static void Main(string[] args)
            {
    
                Class classObj = new Class();
                Console.WriteLine(classObj.readonlyField);//9
    
                Misc.SetVariableyByName(classObj, "readonlyField", 20);//20
                Console.WriteLine(classObj.readonlyField);
             }
