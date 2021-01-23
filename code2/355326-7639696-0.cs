    public class Copier<o, c>
        where o : class, INotifyPropertyChanged
        where c : class, c // ideally new(datetime, o)
    {
    private Dictionary<DateTime, c> copies;
    private Func<o, DateTime, c> copyFunc;
    public Copier(o original, Func<o, DateTime, c> copyFunc)
    {
        this.copyFunc = copyFunc;
        this.copies = new Dictionary<DateTime, c>();
        original.PropertyChanged += 
            this.propertyChangedHandler(object sender, PropertyChangedEventArgs args);
    }
    private void propertyChangedHandler(object sender, PropertyChangedEventArgs args)
    {
        var original = sender as o;
        var now = DateTime.Now;
        this.copies.Add(copyFunc(now, original)); 
    }
}
