            int n1 = Convert.ToInt32(number.Text);
            int n2 = Convert.ToInt32(replace.Text);
            int n3 = Convert.ToInt32(othernumber.Text);
            int temp;
            int result = 0;
            int i = 1;
            while (n1 > 0)
            {
                temp = n1 % 10;
                if (n2 == temp)
                {
                    result += n3 * i;
                }
                else
                {
                    result = result + temp * i;
                }
                i *= 10;
                n1 = n1 / 10;
            }
            afterswap.Text = Convert.ToString(result);
