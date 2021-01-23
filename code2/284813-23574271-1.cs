    namespace YourFavoriteNamespace 
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        public static class Extensions
        {
            public static Queue<string> SplitSeeingQuotes(this string valToSplit, char splittingChar = ',', char escapeChar = '"', 
                bool strictEscapeToSplitEvaluation = true, bool captureEndingNull = false)
            {
                Queue<string> qReturn = new Queue<string>();
                StringBuilder stringBuilder = new StringBuilder();
                bool bInEscapeVal = false;
                for (int i = 0; i < valToSplit.Length; i++)
                {
                    if (!bInEscapeVal)
                    {
                        // Escape values must come immediately after a split.
                        // abc,"b,ca",cab has an escaped comma.
                        // abc,b"ca,c"ab does not.
                        if (escapeChar == valToSplit[i] && (!strictEscapeToSplitEvaluation || (i == 0 || (i != 0 && splittingChar == valToSplit[i - 1]))))
                        {
                            bInEscapeVal = true;    // not capturing escapeChar as part of value; easy enough to change if need be.
                        }
                        else if (splittingChar == valToSplit[i])
                        {
                            qReturn.Enqueue(stringBuilder.ToString());
                            stringBuilder = new StringBuilder();
                        }
                        else
                        {
                            stringBuilder.Append(valToSplit[i]);
                        }
                    }
                    else
                    {
                        // Can't use switch b/c we're comparing to a variable, I believe.
                        if (escapeChar == valToSplit[i])
                        {
                            // Repeated escape always reduces to one escape char in this logic.
                            // So if you wanted "I'm ""double quote"" crazy!" to come out with 
                            // the double double quotes, you're toast.
                            if (i + 1 < valToSplit.Length && escapeChar == valToSplit[i + 1])
                            {
                                i++;
                                stringBuilder.Append(escapeChar);
                            }
                            else if (!strictEscapeToSplitEvaluation)
                            {
                                bInEscapeVal = false;
                            }
                            // *** STINKY CONDITION ***  
                            // Kinda defense, since only `", ` really makes sense.
                            else if ('"' == escapeChar && i + 2 < valToSplit.Length &&
                                valToSplit[i + 1] == ',' && valToSplit[i + 2] == ' ')
                            {
                                i = i+2;
                                stringBuilder.Append("\", ");
                            }
                            // *** EO STINKY CONDITION ***  
                            else if (i+1 == valToSplit.Length || (i + 1 < valToSplit.Length && valToSplit[i + 1] == splittingChar))
                            {
                                bInEscapeVal = false;
                            }
                            else
                            {
                                stringBuilder.Append(escapeChar);
                            }
                        }
                        else
                        {
                            stringBuilder.Append(valToSplit[i]);
                        }
                    }
                }
                // Catch null final entry?  "abc,cab,bca," could be four entries, with the last an empty string.
                if ((captureEndingNull && splittingChar == valToSplit[valToSplit.Length]) || (stringBuilder.Length > 0))
                {
                    qReturn.Enqueue(stringBuilder.ToString());
                }
                return qReturn;
            }
        }
    }
