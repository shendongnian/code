        public string RemoveSpaceAfter(string inputString)
        {
            try
            {
                string[] Split = inputString.Split(new Char[] { ' ' });
                //SHOW RESULT
                for (int i = 0; i < Split.Length; i++)
                {
                    fateh += Convert.ToString(Split[i]);
                }
                return fateh;
            }
            catch (Exception gg)
            {
                return fateh;
            }
        }
