    private void Window_Activated(object sender, EventArgs e)
    {
        int zahler = 0;
        System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\mgleich\source\repos\Inspect\Variablenliste.txt");   //Erstellung Streamreader
        List<YourType> sourceCollection = new List<YourType>();
        while (zahler < 2)
        {
            string line = sr.ReadLine();
            if (line != "" && line != null)
            {
                //create a new Row
                string[] linearray = line.Split(' ');
                //add the elements from linearray[0-2] into the new Row 
                sourceCollection.Add(new YourType()
                {
                    maschinenParameter = linearray[0],
                    valueAdresse = linearray[1]
                });
            }
            else
            {
                zahler++;
            }
        }
        tableAllVar.ItemsSource = sourceCollection;
    }
