    public void TaskOnClick() //getting multi-values
        {
           string filename = "Assets/Text/TEMP/multi-export.txt";
           using (StreamWriter writeFile = new StreamWriter(filename, false))
           {
            foreach (string inputJson in File.ReadLines("Assets/Text/multi-import.txt"))
            {
                string temperature = GetTemperatureByRegex(inputJson);
                Debug.Log(temperature);  
                writeFile.AutoFlush = true;
                Console.SetOut(writeFile);
                writeFile.WriteLine(temperature.ToString());            
            }
          }
        }
