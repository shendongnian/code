    public class TagCleaner
    {
        public string CleanEM(string input)
        {
            var beginTag = "<em>";
            var endTag = "</em>";
            var parsable = input;
            var state = 0;
            var output = string.Empty;
            var done = false;
            while (!done)
            {
                switch (state)
                {
                    case 0:  // new attempt... find <em>
                        {
                            var idx = parsable.IndexOf(beginTag);
                            if (idx < 0)
                            {
                                output = parsable;
                                state = -1;
                            }
                            if (idx > 0)
                            {
                                output = parsable.Substring(0, idx + beginTag.Length);
                            }
                            if (idx == 0)
                            {
                                output = beginTag;
                            }
                            parsable = parsable.Substring(idx + beginTag.Length); //chopped off anything before the <em> tag for next round
                            state = 1; // set state to go find matching </em>                        
                        }
                        break;
                    case 1: // found <em>, now find matching </em>
                        {
                            var idx = parsable.IndexOf(endTag);
                            if (idx < 0)
                            {
                                output += parsable;
                                state = -1;
                            }
                            if (idx > 0)
                            {
                                output += parsable.Substring(0, idx + endTag.Length);
                            }
                            if (idx == 0) //<em></em>... remove the last <em> tag from output...
                            {
                                output = output.Substring(0, output.LastIndexOf(beginTag));
                            }
                            parsable = parsable.Substring(idx + endTag.Length); //chopped off anything before the </em> tag for next round
                            if (parsable.Length < 1)
                                state = -1; //done
                            else
                                state = 2; // set state to find the next <em>
                        }
                        break;
                    case 2: //just found </em>, now look for the next <em>
                        {
                            var idx = parsable.IndexOf(beginTag);
                            if (idx < 0)
                            {
                                output += parsable;
                                state = -1; //done
                            }
                            if (idx >= 0)
                            {
                                var prefix = parsable.Substring(0, idx);
                                var re = new System.Text.RegularExpressions.Regex("^ *$");
                                if (re.IsMatch(prefix)) // found 0 or more spaces between the </em> and <em> tag... 
                                {
                                    output = output.Substring(0, output.LastIndexOf(endTag)); //chop off the last </em> from output
                                    output += prefix; //add the spaces to the output
                                    parsable = parsable.Substring(idx + beginTag.Length);
                                    state = 1; //set state to go find </em>
                                }
                                else // there are other things beside empty spaces in between...
                                {
                                    output += parsable.Substring(0, idx + beginTag.Length);
                                    parsable = parsable.Substring(idx + beginTag.Length);
                                    state = 1; //set state to go find </em>
                                }
                            }
                            if (parsable.Length < 1)
                                state = -1; //done
                        }
                        break;
                    default:
                        done = true;
                        break;
                }
            }
            return output;
        }
    }
