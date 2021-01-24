    static void getNum()
            {
                string[] strNum = (Regex.Split(exp, @"\D+"));
    
                for (int cntr = 0; cntr < strNum.Length; cntr++)
                {
                    if (!string.IsNullOrEmpty(strNum[cntr]))
                    {
                        i[cntr] = int.Parse(strNum[cntr]);
                    }
                }
            }
    
            static void counter()
            {
                cntr2 = 0;
                for (int cntr = 0; cntr < exp.Length; cntr++)
                {
                    if (exp[cntr] == '+')
                    {
                        oper[cntr2] = '+';
                        cntr2++;
                    }
                    else if (exp[cntr] == '-')
                    {
                        oper[cntr2] = '-';
                        cntr2++;
                    }
                    else if (exp[cntr] == '*')
                    {
                        oper[cntr2] = '*';
                        cntr2++;
                    }
                    else if (exp[cntr] == '/')
                    {
                        oper[cntr2] = '/';
                        cntr2++;
                    }
                }
            }
    
            static void oprtr()
            {
                result = i[0];
    
                cntr2 = 1;
                for (int cntr = 0; cntr < oper.Length; cntr++)
                {
                    if (oper[cntr] == '+')
                    {
                        result += i[cntr2];
                    }
                    else if (oper[cntr] == '-')
                    {
                        result -= i[cntr2];
                    }
                    else if (oper[cntr] == '*')
                    {
                        result *= i[cntr2];
                    }
                    else if (oper[cntr] == '/')
                    {
                        if (i[cntr2] == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result /= i[cntr2];
                    }
    
                    cntr2 += 1;
                }
            }
