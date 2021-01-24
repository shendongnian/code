    DataTable table;
       private void createDatatableFromXML()
       {
           table = new DataTable();
           string dataFile = @"DatafileLocation\datafile.xml";
           if (File.Exists(dataFile))
           {
               table.ReadXml(dataFile);
           }
           else
           {
              //Do som messaging
               return;
           }
       }
