    if (url.Contains("error") || url.Contains("Error") == true)
                {
                    Base.ErrorMessage(driver, element);  // screenshot the page 
                    throw new SystemException("Webpage throw error");
                    //Console.WriteLine("Got");
                }
                else
                {
                    Console.WriteLine("Passed");
                }
                }
