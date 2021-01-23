    using System;
    namespace Anagram_Test
    {
        class ClassCheckAnagram
        {
            public int check_anagram(char[] a, char[] b)
            {
                Int16[] first = new Int16[26];
                Int16[] second = new Int16[26];
                int c = 0;
    
                for (c = 0; c < a.Length; c++)
                {
                    first[a[c] - 'a']++;
                }
    
                c = 0;
    
                for (c=0; c<b.Length; c++)
                {
                    second[b[c] - 'a']++;
                   
                }
    
                for (c = 0; c < 26; c++)
                {
                    if (first[c] != second[c])
                        return 0;
                }
    
                return 1;
            }
        }
    }
    
    using System;
    
    namespace Anagram_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                ClassCheckAnagram cca = new ClassCheckAnagram();
                Console.WriteLine("Enter first string\n");
                string aa = Console.ReadLine();
                char[] a = aa.ToCharArray();
    
                Console.WriteLine("\nEnter second string\n");
                string bb = Console.ReadLine();
                char[] b = bb.ToCharArray();
                int flag = cca.check_anagram(a, b);
    
                if (flag == 1)
                    Console.WriteLine("\nThey are anagrams.\n");
                else
                    Console.WriteLine("\nThey are not anagrams.\n");
                Console.ReadKey();
            }
    
        }
    }
