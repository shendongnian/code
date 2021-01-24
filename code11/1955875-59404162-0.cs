     public DataTable ReadTextFile(string filepath,int numberOfColumns)
        {
            DataTable dtTextFile = new DataTable();
    
          for(int col =0; col < numberOfColumns; col++)
            dtTextFile.Columns.Add(new DataColumn("Column" + (col+1).ToString()));
    
           
            string[] readTextfile = System.IO.File.ReadAllLines(@"D:\Rutu\datatest.txt");
    
           
            foreach (string line in readTextfile)
            {
                var cols = line.Split(';');
                DataRow dtrow = dtTextFile.NewRow();
    
                 for(int cIndex=0; cIndex < 3; cIndex++)
                 {
                   dtrow [cIndex] = cols[cIndex];
                 }
                dtTextFile.Rows.Add(dtrow);              
                
            }
           return dtTextFile;
    
        }
