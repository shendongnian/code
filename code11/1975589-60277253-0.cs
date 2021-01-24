    List<siplist> itemList = new List<siplist>();
    for(int i=0;i<3;i++)
    {
        itemList.Add(new siplist() { index = index.Split(',')[i], Date = Date.Split(',')[i], Aunt = AUNT.Split(',')[i] });
    }
    Console.WriteLine(JsonConvert.SerializeObject(itemList));
