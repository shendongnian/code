            DateTime lastTime;
            string lastValue = null;
            StreamReader reader = File.OpenText("path");
            StreamWriter writer = new StreamWriter(File.OpenWrite("newPath"));
            while (!reader.EndOfStream)
            {
                string[] lineData = reader.ReadLine().Split(' ');
                DateTime currentTime = DateTime.Parse(lineData[0]);
                string value = lineData[1];
                if (lastValue != null)
                {
                    while (lastTime < currentTime.AddSeconds(-1))
                    {
                        lastTime = lastTime.AddSeconds(1);
                        writer.WriteLine("{0} {1}", lastTime, lastValue);
                    }
                }
                writer.WriteLine("{0} {1}", currentTime, value);
                lastTime = currentTime;
                lastValue = value;
            }
