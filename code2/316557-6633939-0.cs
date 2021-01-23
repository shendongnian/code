     List<byte[]> patterns = new List<byte[]>() { 
                    new byte[] { 00, 00, 00, 08, 00 }, 
                    new byte[] { 00, 00, 00, 08, 01 }, 
                    new byte[] { 00, 00, 00, 08, 02 }, 
                    new byte[] { 00, 00, 00, 08, 03 } 
                    };
                bool matched = false;
                foreach (byte[] pattern in patterns)
                {
                    while (!matched)
                    {
                        byte[] file = File.ReadAllBytes("C:\\123.cfg");
    
                        var result = Enumerable.Range(0, file.Length - pattern.Length + 1)
                              .Where(i => pattern.Select((b, j) => new { j, b })
                                                 .All(p => file[i + p.j] == p.b))
                              .Select(i => i + pattern.Length - 1);
    
                        int[] PatternArray = result.ToArray();
                        if (result != null)
                            matched = true;
                    }
                }
