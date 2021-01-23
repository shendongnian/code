    public class Dinosaurs : Collection<string>
    {
        public event EventHandler<DinosaursChangedEventArgs> Changed;
    
        protected override void InsertItem(int index, string newItem)
        {
            base.InsertItem(index, newItem);
    
            EventHandler<DinosaursChangedEventArgs> temp = Changed;
            if (temp != null)
            {
                temp(this, new DinosaursChangedEventArgs(
                    ChangeType.Added, newItem, null));
            }
        }
    
        ...
    }
