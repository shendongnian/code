    public class CarModel
    {
        internal CarModel(string manufacturer, string modelName, double seconds0To60, double maxMPH)
        {
            Manufacturer = manufacturer;
            ModelName = modelName;
            Seconds0To60 = seconds0To60;
            MaxMPH = maxMPH;
        }
        public string Manufacturer { get; private set; }
        public string ModelName { get; private set; }
        public double Seconds0To60 { get; private set; }
        public double MaxMPH { get; private set; }
        public override string ToString() { return Manufacturer + " " + ModelName; }
        <#
        String path = "D:\\My Documents\\Visual Studio 2010\\Projects\\Play\\Play\\Content\\testdata.csv";
        List<string[]> parsedData = new List<string[]>();
                try
                {
                    using (StreamReader readFile = new StreamReader(path))
                    {
                        string line;
                        string[] row;
                        while ((line = readFile.ReadLine()) != null)
                        {
                            row = line.Split(',');
                            #>
                            static public readonly CarModel <#=(String)row[0].Replace(" ", "_")#>_<#=Regex.Replace(row[1], @"[\.\(\)-]", "_").Replace(" ", "_")#>  = new CarModel("<#=(String)row[0]#>", "<#=row[1]#>", <#=row[2]#>, <#=row[3]#>);
                            <#
                            parsedData.Add(row);
                        }
                    }
                }catch(Exception e)
                {
                    //left as an excercise for the reader
                }
        #>
    }
}
