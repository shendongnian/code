           string DiagnosesString  =  "250.00 03 350.0001 450.00 01 550.00 02";
           string DiagnosisCodestemp = DiagnosesString.Replace(" 01 ", " ").Replace(" 02 ", " ").Replace(" 03 ", " ").Replace(" 04 ", " ").Replace(" 05 ", " ").Replace(" 06 ", " ").Replace(" 07 ", " ");
            string[] DiagnosisCodesParts = DiagnosisCodestemp.Split();
            foreach (var item in DiagnosisCodesParts)
            {
                string[] parts = item.Split('.');
                string num = parts[1];
                string finalValue = string.Empty;
                if (num.Length > 2)
                {
                    num = num.Replace(num, "00");
                    finalValue =  parts[0]+"."+num;
                }
                else
                {
                    finalValue = parts[0] + "." + num;
                }
                list.Add(finalValue);
            }
