                List<byte> dataNew = new List<byte>();
                byte[] data = File.ReadAllBytes(jpegFilePath);
                int j = 0;
                for (int i = 1; i < data.Length; i++)
                {
                    if (data[i - 1] == (byte)0x1C) // 1C IPTC
                    {
                        if (data[i] == (byte)0x02) // 02 IPTC
                        {
                            if (data[i + 1] == (byte)fileByte) // IPTC field_number, i.e. 0x78 = IPTC_120
                            {
                                j = i;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < j + 2; i++) // add data from file before this field
                    dataNew.Add(data[i]); 
                int countOld = (data[j + 2] & 255) << 8 | (data[j + 3] & 255); // curr field length
                int countNew = valueToAdd.Length; // new string length
                int newfullSize = countOld + countNew; // sum
                byte[] newSize = BitConverter.GetBytes((Int16)newfullSize); // Int16 on 2 bytes (to use 2 bytes as size)
                Array.Reverse(newSize); // changes order 10 00 to 00 10
                for (int i = 0; i < newSize.Length; i++) // add changed size
                    dataNew.Add(newSize[i]);
                for (int i = j + 4; i < j + 4 + countOld; i++) // add old field value
                    dataNew.Add(data[i]);
                byte[] newString = ASCIIEncoding.ASCII.GetBytes(valueToAdd);
                for (int i = 0; i < newString.Length; i++) // append with new field value
                    dataNew.Add(newString[i]);
                for (int i = j + 4 + newfullSize; i < data.Length; i++) // add rest of the file
                    dataNew.Add(data[i]);
                byte[] finalArray = dataNew.ToArray();
                File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(jpegFilePath), "newfile.jpg"), finalArray);                
