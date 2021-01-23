            static int LineNumber(System.IO.Stream s)
            {
                byte[] buffer = new byte[s.Length];
                s.Read(buffer, 0, (int)s.Length);
                string text = System.Text.Encoding.ASCII.GetString(buffer);            
                int idx = 0;
                int line = 0;
                do
                {
                    idx = text.IndexOf('\n', idx);
                    if (idx > -1)
                    {
                        line++;
                        if (s.Position <= idx)
                            return line;
                        if (idx < text.Length - 1)
                            idx++;
                    }
                    else
                        break;
                } while (true);
                return 1;
            }
