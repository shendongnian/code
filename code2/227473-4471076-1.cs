            List<string> outList = new List<string>();
            foreach (string s1 in ListOne)
            {
                foreach (string s2 in ListTwo)
                {
                    if (s1 != s2 &&
                        !outList.Contains(s1 + "-" + s2) &&
                        !outList.Contains(s2 + "-" + s1))
                    {
                        outList.Add(s1 + "-" + s2);
                    }
                }
            }
