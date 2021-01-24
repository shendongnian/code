    using System;
    using System.Text;
    using System.Collections.Generic;
    
    namespace sotest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Movies();
                Console.ReadKey();
            }
    
            public static void Movies()
            {
                List<string> movieList = new List<string>();
                bool check = false;
    
                do
                {
                    StringBuilder movie = new StringBuilder();
    
                    for (int i = 0; i < GetNum(); i++)
                    {
                        movie.Insert(0, Convert.ToString(GetLetter()));
                    }
    
                    movie.Insert(0, " ");
                    movie.Insert(0, Convert.ToString(GetYear()));
                    movie.Insert(0, " ");
    
                    for (int i = 0; i < GetNum(); i++)
                    {
                        movie.Insert(0, Convert.ToString(GetLetter()));
                    }
    
                    if (movieList.Contains(movie.ToString()))
                    {
                        check = false;
                    }
                    else
                    {
                        movieList.Add(movie.ToString());
                        check = true;
                    }
    
                } while (check == false);
    
                Console.WriteLine(movieList[0]);
    
    
            }
    
    
            public static Random _random = new Random();
    
            public static char GetLetter()
            {
                int num = _random.Next(0, 26);
                char let = (char)('a' + num);
                return let;
            }
    
            public static int GetNum()
            {
                int num = _random.Next(4, 11);
                return num;
            }
    
            public static int GetYear()
            {
                int num = _random.Next(1920, 2020);
                return num;
            }
    
        }
    }
