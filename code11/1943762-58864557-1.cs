    public List<Tile> ListFromMatrix {get; set;}
    // when it comes time to serialize
    ListFromMatrix = CreateList();
    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
    {
        XmlSerializer xs = new XmlSerializer(typeof(Game));
        xs.Serialize(fs, this.Game);
    }
    private List<Tile> CreateList()
    {
        var temp = new List<Tile>(Height * Width);
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                temp.Add(Grid[i, j]);
        return temp;
    }
