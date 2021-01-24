class FileReader
{
    static void Second()
    {
        StreamReader reader = new StreamReader(@"D:\asd.txt");
        using(reader)
        {
            int number;
            string line = reader.ReadLine();
            bool success = Int32.TryParse(value.Trim(), out number);
            if (success) {
                Console.WriteLine("Number is:" + number);
            } else {
                Console.WriteLine("Could not parse the number");
            }
        }
    }
}
