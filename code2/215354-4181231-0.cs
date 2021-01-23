    private class Position
    {
        internal int Row;
        internal int Col;
    }
    var txtBoxesDict=new Dictionary<Position, TextBox>();
    txtBoxesDict.Add(new Position{Row=0,Col=0},txtBox0);
