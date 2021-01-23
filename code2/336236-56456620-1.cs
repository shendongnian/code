    /// <summary>
    /// GET - split line in parts using index cuts
    /// </summary>
    /// <param name="iListIndex">Input List of indexes</param>
    /// <param name="iTextLine">Input line to split</param>
    public static List<string> getListWordsFromLine(string iTextLine, int[] iListIndex)
    {
        // INIT
        List<string> retObj = new List<string>(); 
        int currStartPos = 0;
        // GET - clear index list from dupl. and sort it
        int[] tempListIndex = iListIndex.Distinct()
                                        .OrderBy(o => o)
                                        .ToArray();
        // CTRL
        if (tempListIndex.Length != iListIndex.Length)
        {
            // ERR
            throw new Exception("Input  iListIndex contains duplicate indexes");
        }
    
    
        for (int jj = 0; jj < tempListIndex.Length; ++jj)
        {
            try
            {
                // SET - line chunk
                retObj.Add(iTextLine.Substring(currStartPos,
                                               tempListIndex[jj] - currStartPos));
            }
            catch (Exception)
            {
                // SET - line is shorter than expected
                retObj.Add(string.Empty);                    
            }                
            // GET - update start position
            currStartPos = tempListIndex[jj];
        }
        // SET
        retObj.Add(iTextLine.Substring(currStartPos));  
        // RET
        return retObj;
    }
