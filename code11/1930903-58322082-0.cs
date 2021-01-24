    public interface IModel
    {
        IEnumerable<string> Values { get; }
    }
    public class ViewModel : IModel
    {
        public ObservableCollection<string> Values { get; set; }
        IEnumerable<string> IModel.Values => Values;
    }
