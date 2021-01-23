            string vInput = "1500 Kb/s";
            string[] tSize = new string[] { "b/s", "Kb/s", "Mb/s", "Gb/s" };
            string[] tSplit = vInput.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            double vSpeed = Double.Parse(tSplit[0]) / 1024.0;
            vSpeed = Math.Round(vSpeed, 2);
            int i = 0;
            for(i = 0; i < tSize.Length;++i)
            {
                if(tSplit[1].StartsWith(tSize[i]))
                {
                    break;
                }
            }
            string vOutput = vSpeed.ToString() + " " + tSize[i+1];
