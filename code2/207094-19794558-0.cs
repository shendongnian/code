        	SHDocVw.InternetExplorer ie = null; /*INTERNET EXPLORER's OBJECT*/
		ie.Navigate("http://www.example.com/entry"); /*GO TO EXAMPLE.COM*/
                            /*WAIT UNTIL THE BROWSER IS READY AND COMPLETELY LOADED*/
							while (ie.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE) 
                            {
                                Application.DoEvents();
                            }
                            doc = ie.Document;
                            while (doc.readyState != "complete")
                            {
                                Application.DoEvents();
                            }
							/*GET ALL THE INPUT ELEMETS IN A COLLECTION*/
							MSHTML.IHTMLElementCollection collection = doc.getElementsByTagName("INPUT");
                            foreach (mshtml.IHTMLElement elem in collection)
                            {
                                if (elem.getAttribute("name") != null)
                                {
                                    /*IDENTIFY THE INPUT CONTROL BY NAME ATTRIBUTE*/
									if (elem.getAttribute("name").Equals("user"))
                                    {
										/*ENTER USER NAME*/
                                        elem.setAttribute("value", "ABC");
									}
								}
							}
							
