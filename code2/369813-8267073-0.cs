    //No Datamember here
    public bool[,] Data;
    [DataMember(Name="Data")]
    public bool[] XmlData
    {
      get {
        bool[] tmp = new bool[Data.GetLength(0) * Data.GetLength(1)];
        Buffer.BlockCopy(Data, 0, tmp, 0, tmp.Length * sizeof(bool));
        return tmp;
      }
      set {
        bool[,] tmp = new bool[,];
        Buffer.BlockCopy(value, 0, tmp, 0, value.Length * sizeof(bool));
        this.Data = tmp;  
      }
    }
