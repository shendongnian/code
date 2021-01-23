    StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                Console.SetOut(sw);
                Console.Write("test");
                string s = sw.GetStringBuilder().ToString();
                File.WriteAllText("c:\\BACKUP\\temp.txt", s);
            }finally
            {
                if(sw != null)
                {
                    sw.Dispose();
                }
            }
