static void LoadData(string filename)
{
    try
    {
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("File could not be read");
        Console.WriteLine(e.Message);
    }
}
A `StringReader` gives you a `TextReader` over the string you pass in, in your case the filename, rather than the files contents.
Alternatively as pointed out by @Rufus L, you could use `File.ReadAllLines` which will give you an array of strings all in-memory rather than streaming it as you are currently.
