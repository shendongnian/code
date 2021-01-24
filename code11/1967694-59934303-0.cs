            foreach (var c in stringsList)
            {
                if (c.Length > 1 && c[0] == input[0] && c[c.Length-1] == input[1])
                {
                    count += 1;
                }
            }
