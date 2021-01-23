                 try
                {
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader(Path);
                sb.AppendLine(sr.ReadToEnd());
                sb.AppendLine("= = = = = =");
                sb.AppendLine(fileName + " ::::: " + time);
                sr.Dispose();
                if (sw == null)
                {
                    sw = new StreamWriter(Path);
                }
                sw.Write(sb.ToString());
                sw.Dispose();
            }
            catch (Exception e)
            {
            }
