class Solution
{
    public static void Main()
    {
        IDictionary<string, string> phoneBook = new Dictionary<string, string>();
        // First line of input contains 3 which looks like the number of entries in the phone book.
        // You have to read that number first.
        int count = System.Convert.ToInt32(Console.ReadLine());
        // Then, size the string arrays to count.
        String[] name = new string[count];
        String[] phoneNumber = new string[count];
        for (int j = 0; j < 3; j++)
        {
            // Read entire line consisting of name and phone number, and split into two strings
            // consisting of name, and phone number.
            string[] parts = Console.ReadLine().Split(' ');
            name[j] = parts[0].Trim();
            phoneNumber[j] = parts[1].Trim();
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
        // You need to check for each name0 in name1, whether it exists in dictionary.
        foreach (var name0 in name1)
        {
            string number;
            // If name0 is in the phoneBook, number is set to its phone number.
            if (phoneBook.TryGetValue(name0, out number))
            {
                Console.WriteLine(name0 + " = " + number);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
        }
    }
}
