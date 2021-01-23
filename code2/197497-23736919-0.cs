    string[] FastSplit(string sText, char? cSeparator = null, char? cQuotes = null)
        {            
            string[] oTokens;
            if (null == cSeparator)
            {
                cSeparator = DEFAULT_PARSEFIELDS_SEPARATOR;
            }
            if (null == cQuotes)
            {
                cQuotes = DEFAULT_PARSEFIELDS_QUOTE;
            }
            unsafe
            {
                fixed (char* lpText = sText)
                {
                    #region Fast array estimatation
                    char* lpCurrent      = lpText;                    
                    int   nEstimatedSize = 0;
                    while (0 != *lpCurrent)
                    {
                        if (cSeparator == *lpCurrent)
                        {
                            nEstimatedSize++;
                        }
                        lpCurrent++;
                    }
                    nEstimatedSize++; // Add EOL char(s)
                    string[] oEstimatedTokens = new string[nEstimatedSize];
                    #endregion
                    #region Parsing
                    
                    char[] oBuffer = new char[sText.Length];
                    int    nIndex  = 0;
                    int    nTokens = 0;
                    lpCurrent      = lpText;
                    while (0 != *lpCurrent)
                    {
                        if (cQuotes == *lpCurrent)
                        {
                            // Quotes parsing
                            lpCurrent++; // Skip quote
                            nIndex = 0;  // Reset buffer
                            while (
                                   (0       != *lpCurrent)
                                && (cQuotes != *lpCurrent)
                            )
                            {
                                oBuffer[nIndex] = *lpCurrent; // Store char
                                lpCurrent++; // Move source cursor
                                nIndex++;    // Move target cursor
                            }
                        } 
                        else if (cSeparator == *lpCurrent)
                        {
                            // Separator char parsing
                             
                            oEstimatedTokens[nTokens++] = new string(oBuffer, 0, nIndex); // Store token
                            nIndex                      = 0;                              // Skip separator and Reset buffer
                        }
                        else
                        {
                            // Content parsing
                            oBuffer[nIndex] = *lpCurrent; // Store char
                            nIndex++;                     // Move target cursor
                        }
                        lpCurrent++; // Move source cursor
                    }
                    // Recover pending buffer
                    if (nIndex > 0)
                    {
                        // Store token
                        oEstimatedTokens[nTokens++] = new string(oBuffer, 0, nIndex);
                    }
                    // Build final tokens list
                    if (nTokens == nEstimatedSize)
                    {
                        oTokens = oEstimatedTokens;
                    }
                    else
                    {
                        oTokens = new string[nTokens];
                        Array.Copy(oEstimatedTokens, 0, oTokens, 0, nTokens);
                    }
                    #endregion
                }
            }
            // Epilogue            
            return oTokens;
        }
