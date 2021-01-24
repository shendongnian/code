    [Serializable]
    public class House
    {
        public int Id;
        public int People;
        public House(int id, int people)
        {
            Id = id;
            People = people;   
        }
    }
    
    List<House> Houses = new List<House>();
    
    public void Save()
    {
        var stringBuilder = new StringBuilder();
    
        foreach(var house in Houses)
        {
            stringBuilder.Append(house.Id).Append(' ').Append(house.People).Append('/n');
        }
    
        // Now use the file IO method of your choice e.g.
        File.WriteAllText(filePath, stringBuilder.ToString(), Encoding.UTF8);   
    }
    
    public void Load()
    {
        Houses.Clear();
    
        // Use the file IO of choice e.g.
        string readText = File.ReadAllText(path);
    
        var lines = readText.Split('/n', StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            int id = int.TryParse(parts[0]) ? id : -1;
            int people = int.TryParse(parts[1]) ? people : -1;
    
            Houses.Add(new House(id, people));
        }
    }
