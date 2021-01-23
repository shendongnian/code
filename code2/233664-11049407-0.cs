        private string StatisticsFile = @"c:\yourfilename.txt";
        // Read last lines of a file....
        public IList<string> ReadLastLines(int nFromLine, int nNoLines, out bool bMore)
        {
            // Initialise more
            bMore = false;
            try
            {
                char[] buffer = null;
                //lock (strMessages)  Lock something if you need to....
                {
                    if (File.Exists(StatisticsFile))
                    {
                        // Open file
                        using (StreamReader sr = new StreamReader(StatisticsFile))
                        {
                            long FileLength = sr.BaseStream.Length;
                            int c, linescount = 0;
                            long pos = FileLength - 1;
                            long PreviousReturn = FileLength;
                            // Process file
                            while (pos >= 0 && linescount < nFromLine + nNoLines) // Until found correct place
                            {
                                // Read a character from the end
                                c = BufferedGetCharBackwards(sr, pos);
                                if (c == Convert.ToInt32('\n'))
                                {
                                    // Found return character
                                    if (++linescount == nFromLine)
                                        // Found last place
                                        PreviousReturn = pos + 1; // Read to here
                                }
                                // Previous char
                                pos--;
                            }
                            pos++;
                            // Create buffer
                            buffer = new char[PreviousReturn - pos];
                            sr.DiscardBufferedData();
                            // Read all our chars
                            sr.BaseStream.Seek(pos, SeekOrigin.Begin);
                            sr.Read(buffer, (int)0, (int)(PreviousReturn - pos));
                            sr.Close();
                            // Store if more lines available
                            if (pos > 0)
                                // Is there more?
                                bMore = true;
                        }
                        if (buffer != null)
                        {
                            // Get data
                            string strResult = new string(buffer);
                            strResult = strResult.Replace("\r", "");
                            // Store in List
                            List<string> strSort = new List<string>(strResult.Split('\n'));
                            // Reverse order
                            strSort.Reverse();
                            return strSort;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ReadLastLines Exception:" + ex.ToString());
            }
            // Lets return a list with no entries
            return new List<string>();
        }
        const int CACHE_BUFFER_SIZE = 1024;
        private long ncachestartbuffer = -1;
        private char[] cachebuffer = null;
        // Cache the file....
        private int BufferedGetCharBackwards(StreamReader sr, long iPosFromBegin)
        {
            // Check for error
            if (iPosFromBegin < 0 || iPosFromBegin >= sr.BaseStream.Length)
                return -1;
            // See if we have the character already
            if (ncachestartbuffer >= 0 && ncachestartbuffer <= iPosFromBegin && ncachestartbuffer + cachebuffer.Length > iPosFromBegin)
            {
                return cachebuffer[iPosFromBegin - ncachestartbuffer];
            }
            // Load into cache
            ncachestartbuffer = (int)Math.Max(0, iPosFromBegin - CACHE_BUFFER_SIZE + 1);
            int nLength = (int)Math.Min(CACHE_BUFFER_SIZE, sr.BaseStream.Length - ncachestartbuffer);
            cachebuffer = new char[nLength];
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(ncachestartbuffer, SeekOrigin.Begin);
            sr.Read(cachebuffer, (int)0, (int)nLength);
            return BufferedGetCharBackwards(sr, iPosFromBegin);
        }
