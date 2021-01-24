     public class CaruselModel
    {
        public ObservableCollection<CollectionModel> collections { get; set; }
        public string title { get; set; }
        public static ObservableCollection<CaruselModel> carusels { get; set; }
         static CaruselModel()
        {
            carusels = new ObservableCollection<CaruselModel>()
            {
                new CaruselModel(){title="title 1", collections=new ObservableCollection<CollectionModel>(){ new CollectionModel() { Name="Cherry",Age=12},new CollectionModel() { Name="barry",Age=23} } },
                 new CaruselModel(){title="title 2", collections=new ObservableCollection<CollectionModel>(){ new CollectionModel() { Name="Annine",Age=18},new CollectionModel() { Name="Wendy",Age=25} } },
                  new CaruselModel(){title="title 3", collections=new ObservableCollection<CollectionModel>(){ new CollectionModel() { Name="Mattew",Age=12},new CollectionModel() { Name="Leo",Age=23} } },
                   new CaruselModel(){title="title 4", collections=new ObservableCollection<CollectionModel>(){ new CollectionModel() { Name="Jessie",Age=12},new CollectionModel() { Name="Junior",Age=23} } },
                    new CaruselModel(){title="title 5", collections=new ObservableCollection<CollectionModel>(){ new CollectionModel() { Name="Jack",Age=12},new CollectionModel() { Name="Land",Age=23} } }
            };
        }
    }
