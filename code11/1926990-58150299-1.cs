        string line;
        var csv  = new List<CSVline>();
        using (StreamReader sr = new StreamReader(@"filepath of csv"))
        {
            try
            { 
                while ((line = sr.ReadLine()) != null)
                {
                    var values = line.Split(',');
                    csv.Add(new CSVline(values[0],values[1],values[2],values[3],values[4]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read {0}", ex);
            }
          }
