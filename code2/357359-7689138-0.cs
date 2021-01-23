            string s = "1,2,3,4,5,7,8,9,10,11,12,13";
            string[] ints = s.Split(',');
            StringBuilder result = new StringBuilder();
            int num, last = -1;
            bool dash = false;
            for (int ii = 0; ii < ints.Length; ii++)
            {
                num = Int32.Parse(ints[ii]);
                if (num - last > 1)
                {
                    if (dash)
                    {
                        result.Append(last);
                        dash = false;
                    }
                    if (result.Length > 0)
                    {
                        result.Append(",");
                    }
                    result.Append(num);                    
                }
                else
                {
                    if (dash == false)
                    {
                        result.Append("-");
                        dash = true;
                    }
                }
                last = num;
                if (dash && ii == ints.Length - 1)
                {
                    result.Append(num);
                }
            }
            Console.WriteLine(result);
