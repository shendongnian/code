    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter the number\n");
                int num = int.Parse(Console.ReadLine());
                ToRomanNumber tr = new ToRomanNumber();
                string opt=tr.ToRoman(num);
                Console.WriteLine(opt);
            }
        }
        class ToRomanNumber
        {
            string s = "";
    
            public string ToRoman(int number)
            {
    
                if ((number < 0) || (number > 3999))
                {
                    s = s + "Invalid Input";
                }
                if (number < 1) return s;
                if (number >= 1000) { s = s + "M"; ToRoman(number - 1000);}
                if (number >= 900){ s = s + "CM";ToRoman(number - 900);}
                if (number >= 500){ s = s + "D"; ToRoman(number - 500);}
                if (number >= 400){ s = s + "CD"; ToRoman(number - 400);}
                if (number >= 100){ s = s + "C"; ToRoman(number - 100);}
                if (number >= 90){ s = s + "XC"; ToRoman(number - 90);}
                if (number >= 50){ s = s + "L";ToRoman(number - 50);}
                if (number >= 40){ s = s + "XL";ToRoman(number - 40);}
                if (number >= 10){ s = s + "X"; ToRoman(number - 10); }
                if (number >= 9) { s = s + "IX"; ToRoman(number - 9); }
                if (number >= 5) { s = s + "V"; ToRoman(number - 5); }
                if (number >= 4) { s = s + "IV"; ToRoman(number - 4); }
                if (number >= 1) { s = s + "I"; ToRoman(number - 1);}
                return s;
            }
        }
    }
