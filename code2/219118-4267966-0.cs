            int alpha = 1000;
            int numb = 500;
            int numbtotal = 0;
            //string[] values = File.ReadAllLines(subdirectory + "\\" + "values.txt");
            string[] values = new String[] { "1|100", "2|200", "A|30", "B|40" };
            foreach (string value in values)
            {
                string[] valueSplit = value.Split('|');
                switch (valueSplit[0])
                {
                    case "1":
                        numb = Math.Abs(numb - Convert.ToInt32(valueSplit[1]));
                        break;
                    case "2":
                        numb = Math.Abs(numb - Convert.ToInt32(valueSplit[1]));
                        break;
                }
            }
