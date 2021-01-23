    public class SomeClass
    {
        [ImportMany(typeof(IMyInterface))]
        private IEnumerable<IMyInterface> Plugins { get; set; }
    }
