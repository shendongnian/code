    public class MyModel : INotifyPropertyChanged
    {
        ...
        public DelegateRiaQuery<MyContxt,MyEntity> MyModelOperation { get; private set; }
        public MyModel()
        {
            var context = new MyContext();
            MyModelOperation = new DelegateRiaQuery(context, c => c.GetMyModelEntitiesQuery(this.Property1));
        }
    }
