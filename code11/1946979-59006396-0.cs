            String[] result = { "vicky", "vinay@", "google@", "hello" };
            List<string> StringsResult = new List<string>();
    
            for(int l = 0 ; l <= result.Length-1; l++)
            {
                if(result[l].Contains("@"))
                {
                    StringsResult.Add(result[l]);
                }
            }
    
            foreach(String s in StringsResult)
            {
                System.Diagnostics.Debug.Write($"{s} ");
            }
