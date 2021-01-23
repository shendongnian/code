                //load entire file
                StreamReader srFile = new StreamReader(strFileName);
                StringBuilder sbFileContents = new StringBuilder();
                char[] acBuffer = new char[32768];
                while (srFile.ReadBlock(acBuffer, 0, acBuffer.Length)
                    > 0)
                {
                    sbFileContents.Append(acBuffer);
                    acBuffer = new char[32768];
                }
                srFile.Close();
