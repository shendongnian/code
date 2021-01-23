    using System;
    using System.Collections.Generic;
    
    namespace GenericDictionary
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                DictionaryUser dictionaryUser = new DictionaryUser();
                Console.ReadLine();
            }
    
            class GenericFuncDictionary<T> : Dictionary<string, Func<T>>
            {
                public void DisplayValues()
                {
                    foreach(Func<T> fun in this.Values)
                        Console.WriteLine(fun());
                }
            }
    
            class DictionaryUser
            {
                public DictionaryUser()
                {
                    GenericFuncDictionary<string> myDictionary = new GenericFuncDictionary<string>();
                    myDictionary.Add("World", FunWorld);
                    myDictionary.Add("Universe", FunUniverse);
                    myDictionary.DisplayValues();
                }
                public string FunWorld()
                {
                    return "Hello World";
                }
                public string FunUniverse()
                {
                    return "Hello Universe";
                }
            }
        }
    }
