    public List<int[]> doPatternSearch()
            {
    
                List<byte[]> patterns = new List<byte[]>() { 
                    new byte[] { 00, 00, 00, 08, 00 }, 
                    new byte[] { 00, 00, 00, 08, 01 }, 
                    new byte[] { 00, 00, 00, 08, 02 }, 
                    new byte[] { 00, 00, 00, 08, 03 } 
                    };
                //this becomes a container to hold all of the valid results
                List<int[]> response = new List<int[]>();
    
                foreach (byte[] pattern in patterns)
                {
                    byte[] file = File.ReadAllBytes("C:\\123.cfg");
    
                    var result = Enumerable.Range(0, file.Length - pattern.Length + 1)
                          .Where(i => pattern.Select((b, j) => new { j, b })
                                             .All(p => file[i + p.j] == p.b))
                          .Select(i => i + pattern.Length - 1);
    
                    if (result != null)
                    {
                        //if the result is not null then add it to the list.
                        response.Add(result.ToArray<int>());
                    }
                }
    
                return response;
    
            }
