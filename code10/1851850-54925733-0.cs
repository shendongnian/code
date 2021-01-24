    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication103
    {
        class Program
        {
            static void Main(string[] args)
            {
                AlphaNumeric alphaNumeric = new AlphaNumeric();
                for (int i = 0; i < 100010; i++)
                {
                    string sequence = alphaNumeric.GetSequence();
                    Console.WriteLine(sequence);
                }
                Console.ReadLine();
     
            }
        }
        public class AlphaNumeric
        {
            const int NUMBER_PLACES = 5;
            int maxInteger = 1;
            Boolean OVER_FLOW = false;
            static string format = new string('0', NUMBER_PLACES);
            private static int number { get; set; }
            private static List<char> alpha { get; set; }
            public AlphaNumeric()
            {
                for(int i = 0; i < NUMBER_PLACES ; i++) {maxInteger *= 10;}
                number = 1;
                alpha = new List<char>() { 'A', 'A', 'A' };
            }
            public string GetSequence()
            {
                if(OVER_FLOW) return "OVERFLOW ERROR";
                string sequence = string.Join("", alpha) + number.ToString(format);
                Increment();
                return sequence;
            }
            public void Increment()
            {
                number++;
                if (number >= maxInteger)
                {
                    number = 1;
                    for (int i = alpha.Count - 1; i >= 0; i--)
                    {
                        int ascii = (int)alpha[i] + 1;
                        if ((ascii <= (int)'Z'))
                        {
                            alpha[i] = (char)ascii;
                            break;
                        }
                        else
                        {
                            if (i == 0)
                            {
                                OVER_FLOW = true; ;
                            }
                            else
                            {
                                alpha[i] = 'A';
                            }
                        }                    
                    }
                }
            }
        }
    }
