    using System;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine(IncrementBase36("Z006GZYBA1"));
                Console.WriteLine(IncrementBase36("A9"));
                Console.WriteLine(IncrementBase36("AZ"));
                Console.WriteLine(IncrementBase36("1ZZZZZZZZZ"));
            }
            public static string IncrementBase36(string numberBase36)
            {
                var digits = numberBase36.ToCharArray();
                bool carry = true;
                for (int i = digits.Length - 1; i >= 0; --i)
                {
                    if (carry)
                    {
                        if (digits[i] == 'Z')
                        {
                            carry = true;
                            digits[i] = '0';
                        }
                        else
                        {
                            if (digits[i] == '9')
                                digits[i] = 'A';
                            else
                                ++digits[i];
                            carry = false;
                        }
                    }
                }
                if (carry)
                    return '1' + new string(digits);
                else
                    return new string(digits);
            }
        }
    }
