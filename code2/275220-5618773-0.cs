    using (StreamReader sr = new StreamReader(varFile, Encoding.GetEncoding(1250))) {
                string[] stringSeparator = new string[] { "\",\"" };
                if (!sr.EndOfStream)
                    sr.ReadLine();
                while (!sr.EndOfStream) {                    
                    string line = sr.ReadLine(); //.Trim('"');
                    string[] values = line.Split(stringSeparator, StringSplitOptions.None);
                    for (int index = 0; index < values.Length; index++) {
                        MessageBox.Show(values[index].Trim('"'));
                    }
                }
            }
