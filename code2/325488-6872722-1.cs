    public class TitleViewModel
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
    }
    public class PublisherViewModel
    {
        public IEnumerable<TitleViewModel> Titles { get; set; }
        ... some other properties of a publisher that you want to work on in your view    
    }
