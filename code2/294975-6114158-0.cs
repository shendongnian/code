    public sealed class DatabaseProxy : MarshallByRefObject
    {
        public int NumberOfRecords()
        {    
            COMMONIDEACONTROLSLib db = new COMMONIDEACONTROLSLibClass();
            try
            {
                db = objApp.OpenDatabase(file);
                int count = (int)db.Count;
        
                db.Close();
                objApp.CloseDatabase(file);
        
                return count;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
