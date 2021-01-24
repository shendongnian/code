                List<string> text = new List<string>();
                List<string> words = new List<string>();
                foreach (string line in text)
                {
                    bool found = words.FirstOrDefault(w=>line.ToLower().Contains(w.ToLower()))!=null;
                    if (found)
                     {
                         //Do something
                     }
                     else
                     {
                        //Another
                     }
                 }
