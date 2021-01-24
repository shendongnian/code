    //Using a Binary Reader/Writer as the PDF is multitype
    using (var reader = new BinaryReader(File.Open(_file.FullName, FileMode.Open)))
    {
        using (var writer = new BinaryWriter(File.Open(tempFileName.FullName, FileMode.CreateNew)))
        {
    
            //We are searching for the start of the PDF 
            bool searchingForstartOfPDF = true;
            var startOfPDF = "%PDF-".ToCharArray();
    
            //While we haven't reached the end of the stream
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                //If we are still searching for the start of the PDF
                if (searchingForstartOfPDF)
                {
                    //Read the current Char
                    var str = reader.ReadChar();
    
                    //If it matches the start of the PDF signiture
                    if (str.Equals(startOfPDF[0]))
                    {
                        //Check the next few characters to see if they match
                        //keeping an eye on our current position in the stream incase something goes wrong
                        var currBasePos = reader.BaseStream.Position;
                        for (var i = 1; i < startOfPDF.Length; i++)
                        {
                            //If we found a char that isn't in the PDF signiture, then resume the while loop
                            //to start searching again from the next position
                            if (!reader.ReadChar().Equals(startOfPDF[i]))
                            {
                                reader.BaseStream.Position = currBasePos;
                                break;
                            }
                            //If we've reached the end of the PDF signiture then we've found a match
                            if (i == startOfPDF.Length - 1)
                            {
                                //Success
                                //Set the Position to the start of the PDF signiture 
                                searchingForstartOfPDF = false;
                                reader.BaseStream.Position -= startOfPDF.Length;
                                //We are no longer searching for the PDF Signiture so 
                                //the remaining bytes in the file will be directly wrote
                                //using the stream writer
                            }
                        }
                    }
                }
                else
                {
                    //We are writing the binary now
                    writer.Write(reader.ReadByte());
                }
            }
    
        }
    }
