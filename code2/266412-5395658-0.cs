        private void SetNumber(string n)
        {
            int nVal = 0;
           
            if (int.TryParse(n, out nVal))
            {
                if (nVal < 0)
                    number = Math.Abs(nVal);
                else
                    number = nVal;
            }
            else
                number = 0;
        }
