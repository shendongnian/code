        private int[] p = { 19, 17, 16, 13, 11, 9, 7, 5, 4, 3, 2 };
        int Job()
        {
            int n = 1;
            bool found = false;
            while (!found)
            {
                found = true;
                foreach (int i in p)
                {
                    if (n % i != 0)
                    {
                        found = false;
                        break;
                    }
                }
                n++;
            }
            return n - 1;
        }
