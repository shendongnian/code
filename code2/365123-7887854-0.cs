    WebClient wc = new WebClient();
    byte[] result = wc.UploadValues("http://www.externalwebsite.com/dir/page.html", 
                                    "POST", 
                                    new NameValueCollection
                                        {
                                            { "p1", parameter1 }, 
                                            { "p2", parameter2 }
                                        });
