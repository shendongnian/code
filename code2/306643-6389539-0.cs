    public class EntityViewModel<T>
        where T : EntityModel
    {
        public T Entity { get; set; }
        public string UserName { get; set; }
        public string SelectedMenu { get; set; }
    }
