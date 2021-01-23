            using (StreamReader _streamReader = new StreamReader("file.tmp"))
            {
                string[] returnValue;
                string previousLine = null;
                string line = _streamReader.ReadLine();
                while (line.instr() < 0)
                {
                    previousLine = line;
                    line = _streamReader.ReadLine();
                }
                string[] returnValue = new string[] { 
                    previousLine, 
                    line, 
                    _streamReader.ReadLine() 
                };
            }
