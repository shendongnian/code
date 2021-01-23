    private void ExtractVersions(ArrayList list)
        {
            ArrayList IndicesToRemove = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i].ToString();
                int firstIndexOfCurlyClosing = s.IndexOf('}');
                int firstIndexOfBracketClosing = s.IndexOf(']');
                if ((firstIndexOfCurlyClosing > -1) || (firstIndexOfBracketClosing > -1))
                {
                    char type = ' ';
                    int endi = -1;
                    int starti = -1;
                    if ((firstIndexOfBracketClosing == -1) && (firstIndexOfCurlyClosing > -1))
                    { // Only Curly
                        endi = firstIndexOfCurlyClosing;
                        type = '{';
                    }
                    else
                    {
                        if ((firstIndexOfBracketClosing > -1) && (firstIndexOfCurlyClosing == -1))
                        { // Only bracket
                            endi = firstIndexOfBracketClosing;
                            type = '[';
                        }
                        else
                        {
                            // Both
                            endi = Math.Min(firstIndexOfBracketClosing, firstIndexOfCurlyClosing);
                            type = s[endi];
                            if (type == ']')
                            {
                                type = '[';
                            }
                            else
                            {
                                type = '{';
                            }
                        }
                    }
                    starti = s.Substring(0, endi).LastIndexOf(type);
                    if (starti == -1)
                    {
                        throw new Exception("Brackets are not valid.");
                    }
                    // start index, end index and type found. -> make changes
                    if (type == '[')
                    {
                        // Add two new lines, one with the optional part, one without it
                        list.Add(s.Remove(starti, endi - starti+1));
                        list.Add(s.Remove(starti, 1).Remove(endi-1, 1));
                        IndicesToRemove.Add(i);
                    }
                    else
                        if (type == '{')
                        {
                            // Add as many new lines as many alternatives there are. This must be an in most bracket.
                            string alternatives = s.Substring(starti + 1, endi - starti - 1);
                            foreach(string alt in alternatives.Split('|'))
                            {
                                list.Add(s.Remove(starti,endi-starti+1).Insert(starti,alt));
                            }
                            IndicesToRemove.Add(i);
                        }
                } // End of if( >-1 && >-1)
            } // End of for loop
            for (int i = IndicesToRemove.Count-1; i >= 0; i--)
            {
                list.RemoveAt((int)IndicesToRemove[i]);
            }
        }
