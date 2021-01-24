            string sRes = "Apple=3;Orange=10;Mango=12";
            string[] sSplitStrings = sRes.Split(';');
            Dictionary<string,int> listsFruit = new Dictionary<string, int>();
            foreach (string sFruit in sSplitStrings)
            {
                string sLabel = sFruit.Substring(0, sFruit.IndexOf("="));
                string sValue = sFruit.Replace(sLabel + "=", "");
                listsFruit.Add(sLabel, int.Parse(sValue));
            }
