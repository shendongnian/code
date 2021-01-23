    [Export]
    public class OrderViewModelFactory
    {
        [Import]
        public ISomeDependency ImportedDependency { get; set; }
        public OrderViewModel Create(int id)
        {
            return new OrderViewModel(id, this.ImportedDependency);
        }
    }
