c#
using System;
using System.Collections.Generic;
namespace Searching_in_phone_book_using_IDictionary
{
    class MainClass
    {
        public static void Main()
        {
            IDictionary<string, string> phoneBook = new Dictionary<string, string>();
            String[] name = new string[3];
            String[] phoneNumber = new string[3];
            for (int j = 0; j < 3; j++)
            {
                var nameAndPhoneNumber = Console.ReadLine();
                name[j] = nameAndPhoneNumber.Split(' ')[0];
                phoneNumber[j] = nameAndPhoneNumber.Split(' ')[1];
            }
            for (int i = 0; i < 3; i++)
            {
                phoneBook.Add(name[i], phoneNumber[i]);
            }
            String[] name1 = new string[3];
            for (int l = 0; l < 3; l++)
            {
                name1[l] = Console.ReadLine();
            }
            int m = 0;
            foreach (var getData in phoneBook)
            {
                if (getData.Key == name1[m])
                {
                    Console.WriteLine(getData.Key + " = " + getData.Value);
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                m = m + 1;
            }
        }
    }
}
