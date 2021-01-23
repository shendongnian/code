     public static string CleanUpXHTML(string xhtml)
                {
                    int pOpen = 0, pClose = 0, pSlash = 0, pNext = 0, length = 0;
                    pOpen = xhtml.IndexOf("<p", 0);
                    pClose = xhtml.IndexOf(">", pOpen);
                    pSlash = xhtml.IndexOf("</p>", pClose);
                    pNext = xhtml.IndexOf("<p", pClose);
        
                    while (pSlash > -1)
                    {
        
        
                        if (pSlash < pNext)
                        {
                            if (pSlash < pNext)
                            {
                                pOpen = pNext;
                                pClose = xhtml.IndexOf(">", pOpen);
                                pSlash = xhtml.IndexOf("</p>", pClose);
                                pNext = xhtml.IndexOf("<p", pClose);
                            }
                        }
                        else
                        {
                            length = pClose - pOpen + 1;
                            if (pNext < 0 && pSlash > 0)
                            {
                                break;
                            }
        
        
                            xhtml = xhtml.Remove(pOpen, length);
        
                            pOpen = pNext - length;
                            pClose = xhtml.IndexOf(">", pOpen);
                            pSlash = xhtml.IndexOf("</p>", pClose);
                            pNext = xhtml.IndexOf("<p", pClose);
        
        
                        }
        
                        if (pSlash < 0)
                        {
                            int lastp = 0, lastclosep = 0, lastnextp = 0, length3 = 0, TpSlash =0 ;
        
                            lastp = xhtml.IndexOf("<p",pOpen-1);
                            
                            lastclosep = xhtml.IndexOf(">", lastp);
                            lastnextp = xhtml.IndexOf("<p", lastclosep);
                            
        
                            while (lastp >0)
                            {
                                length3 = lastclosep - lastp + 1;
                                xhtml = xhtml.Remove(lastp, length3);
                                if (lastnextp < 0)
                                {
                                    break;
                                }
                                lastp = lastnextp-length3;
                                lastclosep = xhtml.IndexOf(">", lastp);
                                lastnextp = xhtml.IndexOf("<p", lastclosep);
        
                            }
                          
                            break;
                        }
       
                    }
    
                    return xhtml;
        
                }
