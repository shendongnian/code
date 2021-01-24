    class Solution {
      static void Main(String[] args) {
        IDictionary<string, string> phoneBook = new Dictionary<string, string>();
            
            int n = System.Convert.ToInt32(Console.ReadLine());
           
            String[] name = new string[n];
            String[] phoneNumber = new string[n];
            for (int j = 0; j < n; j++)
            {           
                string[] parts = Console.ReadLine().Split(' ');
                name[j] = parts[0].Trim();
                phoneNumber[j] = parts[1].Trim();
            }
            for (int i = 0; i < n; i++)
            {
                phoneBook.Add(name[i], phoneNumber[i]);
            }
            String[] name1 = new string[n];
            for (int l = 0; l < n; l++)
            {
                name1[l] = Console.ReadLine();
            }
           
            foreach (var name0 in name1)
            {
                string number;
              
                if (phoneBook.TryGetValue(name0, out number))
                {
                    Console.WriteLine(name0 + "=" + number);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }
    }
