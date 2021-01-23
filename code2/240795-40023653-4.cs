        public class TestRegionParsing
    {
        private void Test1()
        {
            //this code should not be read
        }
    
        #region ClassName.Test()    
        //Some method that does stuff
        //some stuff
        #endregion ClassName.Test()
    
        #region ClassCName.Random()
        public static void Test()
        {
             //Some more stuff
        }
        #endregion ClassCName.Random()
        
        private void Test2()
        {
            //this code should not be read
        }
    
        #region ClassCName.Random()
        public static void Test3()
        {
             //Some more stuff
        }
        #endregion
    }
