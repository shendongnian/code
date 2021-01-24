    public class Titles : ObservableCollection<Matches>
    {
        //public List<Matches> Monkeys { get; set; }
        public string Intro { get; set; }
        public string Summary { get; set; }
        public Titles(List<Matches> list):base(list)
        {
        }
    }
