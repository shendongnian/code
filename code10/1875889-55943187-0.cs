    string[] models = { "Toyota", "Nissan" };
    using (StreamWriter writer = new StreamWriter("CarsList.txt", true))
    {
        foreach (string s in models)
        {
            writer.WriteLine(s);
            listBoxCars.Items.Add(s);
        }
    }
