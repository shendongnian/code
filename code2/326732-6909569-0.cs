    public class Foo
    {
        public string UserId { get; set; }
        public int UserIntId 
        {
           get { return Int32.Parse(UserId); }
           set { UserId = value.ToString(); }
        }
    }
