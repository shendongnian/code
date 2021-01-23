            string s = "Select a [COLOR] and a [SIZE].";
            string[] sParts = s.Split('[', ']');
            foreach (string sPart in sParts)
            {
                Debug.WriteLine(sPart);
            }
            // Select a 
            // COLOR
            //  and a 
            // SIZE
            // .
