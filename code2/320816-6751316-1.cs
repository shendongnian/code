     class Entry
        {
          public string Rd { get; private set; }
          public string Pn { get; private set; }
          public double X { get; set; }
          // ... declare other properties
        
         // Initializes a new instance of the Entry class
         public Entry(string rawData)
         {
             if (rawData == null)
             {
                throw new ArgumentNullException("rawData", "Nullable data structure can not be processed");             
             }
             string[] values = rawData.Split('\t');
             if (values == null || values.Count() != 6)
             {
                throw new ArgumentException("rawData", "Invalid data structure can not be processed");
             }
             this.Rd = values[0];
             Double.TryParse(values[2], out this.X);
             // ....
         }
        }
