    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    namespace NicParser
    {
        public class NicFileParser
        {
            private readonly string _file;
            private readonly Dictionary<string, string> _nics;
    
            public NicFileParser(string file)
            {
                _file = file;
                _nics = new Dictionary<string, string>();
            }
    
            public void Parse()
            {
                var key = string.Empty;
                var value = new StringBuilder();
    
                try
                {
                    using (var rdr = new StreamReader(_file))
                    {
                        var firstTime = true;
    
                        while (rdr.Peek() > 0)
                        {
                            var line = rdr.ReadLine().Trim();
    
                            if (IsKey(line))
                            {
                                // Once a key is hit, add the previous 
                                // key and values (except the first time).
                                if (!firstTime)
                                {
                                    _nics.Add(key, value.ToString());
                                }
                                else
                                {
                                    firstTime = false;
                                }
    
                                // Assign the key, and clear the previous values.
                                key = line;
                                value.Length = 0;
                            }
                            else
                            {
                                // Add to the values for this nic card.
                                value.AppendLine(line);
                            }
                        }
    
                        // Final line of the file has been read. 
                        // Add the last nic card.
                        _nics.Add(key, value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    // Handle your exceptions however you like...
                }
            }
    
            private static bool IsKey(string line)
            {
                return (!String.IsNullOrEmpty(line)
                     && line.StartsWith("[") 
                     && !line.Contains("."));
            }
    
            // Use this to access the NIC information.
            public Dictionary<string, string> Cards
            {
                get { return _nics; }
            }
        }
    }
