c#
            List<string> MyList = new List<string>{ "One", "two" };
            //Serialize 
            string Temp = JsonConvert.SerializeObject(MyList);
            //Save Data
            using (StreamWriter sw = File.AppendText("C:\\temp\\t.txt"))
            {
                sw.WriteLine(Temp);
            }
            //Load Data
            MyList = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText("C:\\temp\\t.txt"));
