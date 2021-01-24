     public class CSVReader
      {
        string appLocation = System.IO.Directory.GetCurrentDirectory();
              
        public List<MyDataModel> GetNewCSVValue()
        {
            StreamReader streamReader;
            List<MyDataModel> myDataModels = new List<MyDataModel>();
            MyDataModel myDataModel = null;
            var mydataFile = "../../../UnProcessed/data.csv";
            if (File.Exists(mydataFile))
            {
                try
                {
                    streamReader = File.OpenText(mydataFile);
                    while (!streamReader.EndOfStream)
                    {
                        var valueLine = streamReader.ReadLine();
                        myDataModel = new MyDataModel();
                        var csvValues = valueLine.Split(',');
                        if (csvValues != null)
                        {
                            myDataModel.Column1 = csvValues[0];
                            myDataModel.Column2 = csvValues[1];
                            myDataModels.Add(myDataModel);
                        }
                    }
                    streamReader.Close();
                    streamReader = null;
                    // Move the data file to Processed folder
                    //File.Move(mydataFile, 
              // "../../../Processed/data"+DateTime.Now.ToString()+".csv");
                }
                catch (Exception ex)
                {
                    streamReader = null;
                }
            }
            return myDataModels;
        }
    }
