    private void RenderFormattedText(Graphics g, RectangleF bounds, string text, string matchText, Font font, Color colour, bool alignTextToTop)
                {
                    const string spaceCharacter = " ";
                    const string hyphenCharacter = "-";
                    Font fr = null;
                    Font fi = null;
                    try
                    {
                        // Get teh matching characters.
                        bool[] charactersMatched = Get_CharacterArray(text);
        
                        // Setup the fonts and bounds.
                        fr = new Font(font.FontFamily, font.Size, FontStyle.Regular);
                        fi = new Font(font.FontFamily, font.Size, FontStyle.Bold | FontStyle.Underline);
                        SizeF fontSize = g.MeasureString(text, fi, 0, StringFormat.GenericTypographic);
                        RectangleF area = bounds;
        
                        // Loop all the characters of the phrase
                        for (int pos = 0; pos < charactersMatched.Length; pos++)
                        {
                            // Draw the character in the appropriate style.
                            string output = text.Substring(pos, 1);
                            if (charactersMatched[pos])
                            {
                                area.X += DrawFormattedText(g, area, output, fi, colour);
                            }
                            else
                            {
                                area.X += DrawFormattedText(g, area, output, fr, colour);
                            }
        
                            // Are we towards the end of the line?
                            if (area.X > (bounds.X + bounds.Width - 1))
                            {
                                // are we in the middle of a word?
                                string preOutput = spaceCharacter;
                                string postOutput = spaceCharacter;
        
                                // Get at the previous character and after character
                                preOutput = text.Substring(pos - 1, 1);
                                if ((pos + 1) <= text.Length)
                                {
                                    postOutput = text.Substring(pos + 1, 1);
                                }
        
                                // Are we in the middle of a word? if so, hyphen it!
                                if (!preOutput.Equals(spaceCharacter) && !postOutput.Equals(spaceCharacter))
                                {
                                    if (charactersMatched[pos])
                                    {
                                        area.X += DrawFormattedText(g, area, hyphenCharacter, fi, colour);
                                    }
                                    else
                                    {
                                        area.X += DrawFormattedText(g, area, hyphenCharacter, fr, colour);
                                    }
                                }
                            }
        
                            // Are we at the end of the line?
                            if (area.X > (bounds.X + bounds.Width))
                            {
                                area.X = bounds.X;
                                area.Y += fontSize.Height + 2;
                            }
                        }
                    }
                    finally
                    {
                        fr.Dispose();
                        fi.Dispose();
                    }
                }
