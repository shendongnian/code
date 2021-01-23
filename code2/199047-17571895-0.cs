        private string TwosComplimentMath(string value1, string value2)
        {
            char[] binary1 = value1.ToCharArray();
            char[] binary2 = value2.ToCharArray();
            bool carry = false;
            char[] calcResult = new char[16];
            for (int i = 15; i >= 0; i--)
            {
                if (binary1[i] == binary2[i])
                {
                    if (binary1[i] == '1')
                    {
                        if (carry)
                        {
                            calcResult[i] = '1';
                            carry = true;
                        }
                        else
                        {
                            calcResult[i] = '0';
                            carry = true;
                        }
                    }
                    else
                    {
                        if (carry)
                        {
                            calcResult[i] = '1';
                            carry = false;
                        }
                        else
                        {
                            calcResult[i] = '0';
                            carry = false;
                        }
                    }
                }
                else
                {
                    if (carry)
                    {
                        calcResult[i] = '0';
                        carry = true;
                    }
                    else
                    {
                        calcResult[i] = '1';
                        carry = false;
                    }
                }
            }
            string result = new string(calcResult);
            return result;
        }
