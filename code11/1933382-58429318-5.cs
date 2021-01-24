    public class Bank : IDepartment
        {
            public int LfdNr { get; set; }
    
            public string Kennung { get; set; }
    
            public string Name { get; set; }
    
            public string Straße { get; set; }
    
            public string PLZ { get; set; }
    
            public string Ort { get; set; }
    
            public DateTime TSCREATE { get; set; }
    
            public DateTime TSUPDATE { get; set; }
    
            public void CreateAndGetValues(SqlDataReader dataReader)
            {
            }
    
            public Object GetAndReadValues(SqlDataReader dataReader)
            {
    
                Bank ThereturnObject = new Bank();
                ThereturnObject.LfdNr = Convert.ToInt32(dataReader.GetValue(0));
                ThereturnObject.Kennung = dataReader.GetValue(1).ToString();
                ThereturnObject.Name = dataReader.GetValue(2).ToString();
                ThereturnObject.Straße = dataReader.GetValue(3).ToString();
                ThereturnObject.PLZ = dataReader.GetValue(4).ToString();
                ThereturnObject.Ort = dataReader.GetValue(5).ToString();
                ThereturnObject.TSCREATE = DateTime.ParseExact(dataReader.GetValue(6).ToString().Trim(), "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                ThereturnObject.TSUPDATE = DateTime.ParseExact(dataReader.GetValue(7).ToString().Trim(), "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                return ThereturnObject;
    
    
            }
