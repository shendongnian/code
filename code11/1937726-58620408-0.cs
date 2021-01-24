    public class HomePageMenuItem
    {
        public HomePageMenuItem()
       {
          TargetType = typeof(ClientInformationMenu);
       }
        public bool IsHome{ get; set;}
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
