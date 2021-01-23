            private string GetBDEConfigText(string fileName)
        {
            StringBuilder textOut = new StringBuilder();
            byte[] fileContents = File.ReadAllBytes(fileName);
            foreach (byte fileByte in fileContents)
            {
                switch (fileByte)
                {
                    case 0:
                        {
                            // Leave unchanged, strip out binary character
                            break;
                        }
                    case 1:
                        {
                            // Leave unchanged, strip out binary character
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            textOut.Append(Environment.NewLine);
                            break;
                        }
                    case 4:
                        {
                            textOut.Append('=');
                            break;
                        }
                    default:
                        {
                            textOut.Append((char)fileByte);
                            break;
                        }
                }
            }
            return textOut.ToString();
        }
