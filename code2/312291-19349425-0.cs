        /// <summary>
        /// Copy data from a file to an other, replacing search term, ignoring case.
        /// </summary>
        /// <param name="originalFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="searchTerm"></param>
        /// <param name="replaceTerm"></param>
        private static void ReplaceTextInBinaryFile(string originalFile, string outputFile, string searchTerm, string replaceTerm)
        {
            byte b;
            //UpperCase bytes to search
            byte[] searchBytes = Encoding.UTF8.GetBytes(searchTerm.ToUpper());
            //LowerCase bytes to search
            byte[] searchBytesLower = Encoding.UTF8.GetBytes(searchTerm.ToLower());
            //Temporary bytes during found loop
            byte[] bytesToAdd = new byte[searchBytes.Length];
            //Search length
            int searchBytesLength = searchBytes.Length;
            //First Upper char
            byte searchByte0 = searchBytes[0];
            //First Lower char
            byte searchByte0Lower = searchBytesLower[0];
            //Replace with bytes
            byte[] replaceBytes = Encoding.UTF8.GetBytes(replaceTerm);
            int counter = 0;
            using (FileStream inputStream = File.OpenRead(originalFile)) {
                //input length
                long srcLength = inputStream.Length;
                using (BinaryReader inputReader = new BinaryReader(inputStream)) {
                    using (FileStream outputStream = File.OpenWrite(outputFile)) {
                        using (BinaryWriter outputWriter = new BinaryWriter(outputStream)) {
                            for (int nSrc = 0; nSrc < srcLength; ++nSrc)
                                //first byte
                                if ((b = inputReader.ReadByte()) == searchByte0
                                    || b == searchByte0Lower) {
                                    bytesToAdd[0] = b;
                                    int nSearch = 1;
                                    //next bytes
                                    for (; nSearch < searchBytesLength; ++nSearch)
                                        //get byte, save it and test
                                        if ((b = bytesToAdd[nSearch] = inputReader.ReadByte()) != searchBytes[nSearch]
                                            && b != searchBytesLower[nSearch]) {
                                            break;//fail
                                        }
                                        //Avoid overflow. No need, in my case, because no chance to see searchTerm at the end.
                                        //else if (nSrc + nSearch >= srcLength)
                                        //    break;
                                    
                                    if (nSearch == searchBytesLength) {
                                        //success
                                        ++counter;
                                        outputWriter.Write(replaceBytes);
                                        nSrc += nSearch - 1;
                                    }
                                    else {
                                        //failed, add saved bytes
                                        outputWriter.Write(bytesToAdd, 0, nSearch + 1);
                                        nSrc += nSearch;
                                    }
                                }
                                else
                                    outputWriter.Write(b);
                        }
                    }
                }
            }
            Console.WriteLine("ReplaceTextInBinaryFile.counter = " + counter);
        }
