     catch (Exception e)
                {
                if (e.Data != null)
                    {
    			foreach (DictionaryEntry de in e.Data)
                    	Console.WriteLine("    The key is '{0}' and the value is: {1}", 
                                                        de.Key, de.Value);                	
                    }
                }
