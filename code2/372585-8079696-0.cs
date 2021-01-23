                try
                {
                    count[p[i].Trim()] = count[p[i]] + 1;
                }
                catch
                {
                    count.Add(p[i], 1);
                }
            }
