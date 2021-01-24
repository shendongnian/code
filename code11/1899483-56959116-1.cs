        dynamic array = JsonConvert.DeserializeObject("{ \"profile1\": { }, \"profile2\": { } }");
        foreach (var item in array)
        {
            debug_tb.Text += item.Name; //Gives me each values of the "profile1 object"
        }
        Console.WriteLine(text);
        Console.ReadLine();
