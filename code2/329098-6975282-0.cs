    public class Item
    {
       public int Col1 { get; set; }
       public int Col2 { get; set; }
       public int Col3 { get; set; }
       public int Col4 { get; set; }
       public bool CanRemove { get { return Col2==0 && Col3 == 0 && Col4 == 0; } }
