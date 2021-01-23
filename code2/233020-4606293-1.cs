        const int MAX_ATTEMPTS = 10;
        Random r = new Random();
        string nlist = "2, 34, 10";
        public int RandomPos(int max_val)
        {
            List<string> used = nlist.Replace(" ","").Split(',').ToList();
            return _RandomPos(MAX_ATTEMPTS, max_val, used);
        }
        private int _RandomPos(int tl, int max, List<string> used)
        {
            if (tl <= 0)
                throw new Exception("Could not generate random number. Too many tries.");
            else
            {
                int rnum = r.Next(max);
                if (!used.Contains(rnum.ToString()))
                {
                    nlist += "," + rnum.ToString();
                    return rnum;
                }
                else
                    return _RandomPos(tl - 1, max, used);
            }
        }
