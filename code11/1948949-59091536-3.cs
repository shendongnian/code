    public class ObservableCollectionHelper<T> where T : IEntity, IMarkDeleted
    {
        public static T NewItem()
        {
            return Activator.CreateInstance<T>();
        }
        private void LoadCollection(ObservableCollection<T> observableCollection)
        {
        }
    
        private void DeleteCollection(ObservableCollection<T> observableCollection)
        {
        }
    }
