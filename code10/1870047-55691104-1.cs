    var item = JsonConvert.DeserializeObject<RootObject>(input);
    for (int i = 0; i < item.Addition.Easy.Count(); i++)
    {
        item.Addition.Easy[i] = appendix[rand.Next(appendix.Length)] + " " + item.Addition.Easy[i];
    }
    var jsonResult = JsonConvert.SerializeObject(item, Formatting.Indented);
    Console.WriteLine(jsonResult);
