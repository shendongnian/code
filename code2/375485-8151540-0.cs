            if (File.Exists(fileName))
            {
                int counter = 1;
                StringBuilder sb = new StringBuilder();
                foreach (string s in File.ReadAllLines(fileName, Encoding.Default))
                {
                    if (s.Contains("</head>"))
                    {
                        s= "<img src=\"result_files\\image003.png\"/>" + line;
                    }
                        sb.AppendLine(s);
                    counter++;
                }
                File.WriteAllText(fileName, sb.ToString(), Encoding.Default);
            }
