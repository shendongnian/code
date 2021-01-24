    String[] result = { "vicky", "vinay@", "google@", "hello" };
    
                var Listbox = new List<string>();
                for (int l = 0; l <= result.Length; l++)
                {
                    if (result[l].Contains("@"))
                    {
                        Listbox.Add(result[l]);
                    }
                }
