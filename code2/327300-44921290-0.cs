            CSVExtractor extractor = new CSVExtractor();
            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";
            TableDetector tdetector = new TableDetector();
            tdetector.RegistrationKey = "demo";
            tdetector.RegistrationName = "demo";
                // Load the document
            extractor.LoadDocumentFromFile("C:\\sample.pdf");
            tdetector.LoadDocumentFromFile("C:\\sample.pdf");
               int pageCount = tdetector.GetPageCount();
                for (int i = 1; i <= pageCount; i++)
                {
                    int j = 1;
                   
                        do
                        {
                                extractor.SetExtractionArea(tdetector.GetPageRect_Left(i),
                                tdetector.GetPageRect_Top(i),
                                tdetector.GetPageRect_Width(i),
                                tdetector.GetPageRect_Height(i)
                            );
                            // and finally save the table into CSV file
                            extractor.SavePageCSVToFile(i, "C:\\page-" + i + "-table-" + j + ".csv");
                            j++;
                        } while (tdetector.FindNextTable()); // search next table
                }
