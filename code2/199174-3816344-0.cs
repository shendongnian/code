    public struct MyStruct
    {
    	public DateTime StartDate { get; set; }
    	public int Qty { get; set; }
    	public int Size { get; set; }
    }
    ...
    List<MyStruct> MyList = new List<MyStruct>();
    ...
    MyList.Sort((item1, item2) => item1.Qty.CompareTo(item2.Qty)); //ascending sort
    ...
    MyList.Sort((item1, item2) => item2.Qty.CompareTo(item1.Qty)); //descending sort
