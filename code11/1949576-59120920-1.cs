    public class Item
    {
        public string Firstame {get; set;}
        public string Lasttame {get; set;}
        public DateTime Date{get; set;}
        ...
    
        public override string ToString()
        {
              return $"{Firstname},{LastName},{Date.ToString("yyyy/MM/dd")}";
        }
    }
