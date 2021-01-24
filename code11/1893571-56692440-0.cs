                while ((ln = Rdr.ReadLine()) != null)
                {
                    NewFile.AppendLine(ln);
                    if (ln.StartsWith("UserId"))
                    {
                        ln = "Sharing";
                        NewFile.AppendLine(ln);
                    }
                }
