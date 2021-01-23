    static void Main(string[] args)
    {
        string word = "hello";
        string temp = word;
        string result = string.Empty;
        Random rand = new Random();
        for (int a = 0; a < word.Length; a++)
        {
            //multiplied by a number to get a better result, it was less likely for the last index to be piked
            int temp1 = rand.Next(0, (temp.Length - 1) * 3);
            result += temp[temp1 % temp.Length];
            temp = temp.Remove(temp1 % temp.Length, 1);
        }
        Console.WriteLine(result);
    }
}
