        decimal totalPrice = 0;
        StreamReader reader = new StreamReader("your file fullpath");
        while(!reader.EndOfStream)
        {
            decimal price = 0;
            decimal.TryParse(reader.ReadLine().Split(',')[1], out price);
            totalPrice += price;
        }
        reader.Close();
