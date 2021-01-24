        Addebito addebito;
        using (HotelContext context = new HotelContext())
        {
            addebito = context.Addebito.Find(3);
        }
        for (int j = 0; j < 3; j++)
        {
            soggiorno.Addebiti.Add(addebito);
        }
