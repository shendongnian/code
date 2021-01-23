                    // Use the HttpHeader Content-Type in preference to the one set in META
                    doc.Encoding = webresponse.ContentEncoding;
                }
                else if (doc.Encoding == String.Empty)
                {
                    doc.Encoding = enc; // default
                }
                //http://www.c-sharpcorner.com/Code/2003/Dec/ReadingWebPageSources.asp
                System.IO.StreamReader stream = new System.IO.StreamReader
                    (webresponse.GetResponseStream(), System.Text.Encoding.GetEncoding(doc.Encoding));
