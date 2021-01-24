    using (var sr = new StreamReader("PATH TO INPUT FILE"))
    {
        using (var sw = new StreamWriter("PATH TO OUTPUT FILE"))
        {
            var line = sr.ReadLine();
    
            while (line != null)
            {
                sw.WriteLine(line);
    
                if (line.Contains("[names]"))
                {
                    sw.Close();
                    sr.Close();
                }
                else
                {                            
                    line = sr.ReadLine();
                }                        
            }
        }
    }
