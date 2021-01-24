    static void Main(string[] args)
    {
        string[] names1 = new string[] { "Name", "Dog", "Cat" };
        string[] names2 = new string[] { "Ocelot", "Picture", "Stark" };
        Dictionary<string, string> stringValues = new Dictionary<string, string>();
        for (int i = 0; i < names1.Length; i++)
        {
            stringValues.Add(String.Format(names1[i] + "{0}", i.ToString()), names1[i]);
        }
        for (int i = 0; i < names2.Length; i++)
        {
            stringValues.Add(String.Format(names2[i] + "{0}", i.ToString()), names2[i]);
        }
        foreach (KeyValuePair<string, string> val in stringValues)
        {
            Console.WriteLine(string.Format("Key = {0}, Value = {1}", val.Key, val.Value));
        }
        Console.ReadLine();
       
    }
