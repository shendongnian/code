            Console.WriteLine("Enter any string");
            string str1, result="", str = Console.ReadLine();
            char [] array= str.ToCharArray();
            int i=0;
            for (i = 0; i < str.Length;i++ )
            {
              if ((i != (str.Length - 1)))
              { if (array[i] == array[i + 1]) 
                {
                    str1 = str.Trim(array[i]);
                }
                else
                {
                    result += array[i];
                }
              }
              else
              {
              result += array[i];
              }                    
            }
            Console.WriteLine(result);
