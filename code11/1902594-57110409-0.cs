        public static int Main(string[] args)
        {
            UpdateLicenceField(2284, "LastStorageFullAlert", DateTime.Now);
            UpdateLicenceField(2284, "IsProcessing", true);
            UpdateLicenceField(2284, "RegSource", "this is a string");
            UpdateLicenceField(2284, "ProcessFilesDelay", 200);
            return 1;
        }
        public static void UpdateLicenceField(int LicenceID, string Field, object Value)
        {
            using (BACCloudModel BACdb = new BACCloudModel())
            {
                Licence licence = BACdb.Licence.Where(x => x.ID == LicenceID && x.Deleted == false).FirstOrDefault();
                if (licence != null)
                {
                    var fieldvalue = licence.GetType().GetProperty(Field);
                    var ftype = fieldvalue.PropertyType;
                    var vtype = Value.GetType();
                    if (ftype == vtype)
                    {
                        object[] Values = { Value };  
                        licence.GetType().GetProperty(Field).SetMethod.Invoke(licence, Values);
                        BACdb.SaveChanges();
                    }
                }
            }
        }   
