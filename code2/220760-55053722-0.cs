    string[] sbytes   = sl.Split(',');
                        byte[] b          = new byte[sbytes.Length];
                        for (int j = 0; j < sbytes.Length; j++)
                        {
                            byte newByte  = byte.Parse(sbytes[j], System.Globalization.NumberStyles.HexNumber);
                            b[j]          = newByte;
                        }
