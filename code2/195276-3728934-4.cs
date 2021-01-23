    static void Main(string[] args)
            {
    
                Class classObj = new Class();
                Console.WriteLine(classObj.MyField());//9
    
                Misc.SetVariableyByName(classObj, "readonlyField", 20);//20
                Console.WriteLine(classObj.MyField());
             }
