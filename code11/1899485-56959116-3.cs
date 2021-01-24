        dynamic array = JsonConvert.DeserializeObject("{ \"profile1\": { }, \"profile2\": { } }");
        foreach (var item in array)
        {
            debug_tb.Text += item.Name; //Gives the name of the object
        }
        Console.WriteLine(text);
        Console.ReadLine();
