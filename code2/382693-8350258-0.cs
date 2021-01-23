        Stopwatch stop1 = new Stopwatch();
        Stopwatch stop2 = new Stopwatch();
        //do test 100 000 times
        for (int j = 0; j < 100000; j++)
        {
            //generate fake data
            //object with 50 properties
            StringBuilder json = new StringBuilder();
            json.Append('{');
            for (int i = 0; i < 100; i++)
            {
                json.Append(String.Format("prop{0}:'val{0}',", i));
            }
            json.Length = json.Length - 1;
            json.Append('}');
            var line = json.ToString();
            stop1.Start();
            var serializer = new JavaScriptSerializer();
            var jsonObject = serializer.DeserializeObject(line) as Dictionary<string, object>;
            stop1.Stop();
            stop2.Start();
            var caseInsensitiveDictionary = new Dictionary<string, object>(jsonObject, StringComparer.OrdinalIgnoreCase);
            stop2.Stop();
        }
        Console.WriteLine(stop1.Elapsed);
        Console.WriteLine(stop2.Elapsed);
        Console.Read();
