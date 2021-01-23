    namespace ExtensionMethods
    {
        public static class MyExtensions
        {
            public static void UpdateValue(this DataTable dt)
            {
                // add code to update data in the DataTable 
            }
        }   
    }
    
    // in another class...
    DataTable myDataTable = (Get DataTable object);
    myDataTable.UpdateValue();
