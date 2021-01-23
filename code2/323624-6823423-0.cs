            string data = "J6      INT-00113G  227.905  174.994  180  SOIC8\r\nJ3      INT-00113G  227.905  203.244  180  SOIC8\r\nU13     EXCLUDES    242.210  181.294  180  QFP128\r\nU3      IC-00276G   236.135  198.644  90   BGA48\r\nU12     IC-00270G   250.610  201.594  0    SOP8\r\nJ1      INT-00112G  269.665  179.894  180  SOIC16\r\nJ2      INT-00112G  269.665  198.144  180  SOIC16\r\n";
            // Split on new line
            string[] lines = data.Split(new string[] {"\r\n"}, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            foreach (string line in lines)
            {
                // Find the last space in the line
                int lastSpace = line.LastIndexOf(' ');
                // delete the end of the string from the last space
                string newLine = line.Remove(lastSpace);
                // rebuild string using stringBuilder
                result.AppendLine(newLine);
            }
            Console.WriteLine("Old List:");
            Console.Write(data);
            Console.WriteLine("New List:");
            Console.Write(result);
        }
