    List<RtfProcessor> fileProcessors = new List<RtfProcessor>();
                using (StringReader reader = new StringReader(ex))
                {
                    string line;
    
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split(',');
                        RtfProcessor rtfProcessor = new RtfProcessor();
                        rtfProcessor.Name = splitLine[0].Trim();
                        rtfProcessor.WordRtfRegex = line.Split(',')[1].Trim();
                        rtfProcessor.WordRtfRegex = line.Split(',')[2].Trim();
                        fileProcessors.Add(rtfProcessor);
                    }
                }
