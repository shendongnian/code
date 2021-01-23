           Dictionary <string, bool> theDict = new Dictionary<string,bool> (); 
           string input= @"abc [xyz] [123] asdasd";
           string[] a2;
           string[] a1 = input.Split('[');
           for (int i = 0; i< a1.Length; i++)
           {
               a2 = a1[i].Split(']');
               if (a2.Length == 1)
                   theDict.Add(a2[0], false);  // no special formatting
               else
               {
                   theDict.Add(a2[0], true);   // special formatting
                   theDict.Add(a2[1], false);
               }
           }
