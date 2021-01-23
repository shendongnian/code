    //****** Result:: Regex.Split(code, "#region")  
    public class TestRegionParsing
    {
        private void Test1()
        {
            //this code should not be read
        }
         ClassName.Test()    
        //Some method that does stuff
        //some stuff
        #endregion ClassName.Test()
         ClassCName.Random()
        public static void Test()
        {
             //Some more stuff
        }
        #endregion ClassCName.Random()
        private void Test2()
        {
            //this code should not be read
        }
         ClassCName.Random()
        public static void Test3()
        {
             //Some more stuff
        }
        #endregion
    }
    //****** Result:: GetCodeRegions(code)
    //Some method that does stuff
    //some stuff
        public static void Test()
    {
         //Some more stuff
    }
        public static void Test3()
    {
         //Some more stuff
    }
    //****** Result:: Utils.GetRegionsFromCShapFile(csharpFinePath)
    Region name converted:1.cs 
        //Some method that does stuff
        //some stuff
    Region name converted:2.cs 
        public static void Test()
        {
             //Some more stuff
        }
    Region name converted:3.cs 
        public static void Test3()
        {
             //Some more stuff
        }
