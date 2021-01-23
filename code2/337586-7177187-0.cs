            string[] DiagnosisCodesParts = DiagnosisCodestemp.Split();
            foreach (var item in DiagnosisCodesParts)
            {
                string[] parts = item.Split('.');
                string num = parts[1];
                if (num.Length > 2)
                {
                    num = num.Replace(num, "00");
                }
            }
