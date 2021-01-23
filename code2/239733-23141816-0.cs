    public interface IPerson<CollectionType> where CollectionType : ICollection<string>
    {
        CollectionType NickNames { get; set; }
    }
    
    class ObservablePerson : IPerson<ObservableCollection<string>>
    {
        public ObservableCollection<string> NickNames { get; set; }
    }
    public class ListPerson : IPerson<List<string>>
    {
        public List<string> NickNames { get; set; }
    }
