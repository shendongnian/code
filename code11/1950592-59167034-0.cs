static void LoadData(string filename)
{
    try
    {
        using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
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
