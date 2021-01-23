            // Extract Files from Submit PDF
            Dictionary<string, byte[]> files = new Dictionary<string, byte[]>();
            PdfDictionary names;
            PdfDictionary embeddedFiles;
            PdfArray fileSpecs;
            int eFLength = 0;
            names = writeReader.Catalog.GetAsDict(PdfName.NAMES); // may be null, writeReader is the PdfReader for a PDF input stream
            if (names != null)
            {
                embeddedFiles = names.GetAsDict(PdfName.EMBEDDEDFILES); //may be null
                if (embeddedFiles != null)
                {
                    fileSpecs = embeddedFiles.GetAsArray(PdfName.NAMES); //may be null
                    if (fileSpecs != null)
                    {
                        eFLength = fileSpecs.Size;
                        for (int i = 0; i < eFLength; i++)
                        {
                            i++; //objects are in pairs and only want odd objects (1,3,5...)
                            PdfDictionary fileSpec = fileSpecs.GetAsDict(i); // may be null
                            if (fileSpec != null)
                            {
                                PdfDictionary refs = fileSpec.GetAsDict(PdfName.EF);
                                foreach (PdfName key in refs.Keys)
                                {
                                    PRStream stream = (PRStream)PdfReader.GetPdfObject(refs.GetAsIndirectObject(key));
                                    if (stream != null)
                                    {
                                        files.Add(fileSpec.GetAsString(key).ToString(), PdfReader.GetStreamBytes(stream));
                                    }
                                }
                            }
                        }
                    }
                }
            }
