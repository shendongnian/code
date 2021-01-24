    public class Operation
    {
        public string Name { get; set; }
        public int Id { get; set; }
    
        public ObservableCollection<Parameters> Parameters { get; set; }
    
        public Operation()
        {
            Parameters = new ObservableCollection<Parameters>();
        }
    }
