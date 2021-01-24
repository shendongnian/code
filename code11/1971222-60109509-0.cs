     public ObservableCollection<Rootobject> list { get; set; }
        public MainPage()
        {
            InitializeComponent();
            var datas = @"{
    'field1':'name1',
    'field2':'name2',
    'data':[
    {
    'type1':'name1',
    'type2':'name2'
    },
    {
    'type1':'name3',
    'type2':'name4'
    }
    ]
    }";
            var jsondata = JsonConvert.DeserializeObject<Rootobject>(datas);
            list = new ObservableCollection<Rootobject>();
            list.Add(jsondata);
            Grid grid = new Grid() { RowSpacing = 5, ColumnSpacing = 5, };
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            var field1 = new Label()
            {
                Text = "field1",
                VerticalOptions = LayoutOptions.Center
            };
            var field2 = new Label()
            {
                Text = "field2",
                VerticalOptions = LayoutOptions.Center
            };
            var data = new Label()
            {
                Text = "data",
                HorizontalOptions = LayoutOptions.Center
            };
            var type1 = new Label()
            {
                Text = "type1",
            };
            var type2 = new Label()
            {
                Text = "type2",
            };
            var boxview = new BoxView()
            {
                BackgroundColor = Color.Black,
                HeightRequest = 1
            };
            grid.Children.Add(field1, 0, 0);
            Grid.SetRowSpan(field1, 2);
            grid.Children.Add(field2, 1, 0);
            Grid.SetRowSpan(field2, 2);
            grid.Children.Add(data, 2, 0);
            Grid.SetColumnSpan(data, 2);
            grid.Children.Add(type1, 2, 1);
            grid.Children.Add(type2, 3, 1);
            grid.Children.Add(boxview, 0, 2);
            Grid.SetColumnSpan (boxview,4);
            foreach (var item in list)
            {
                var field1_value = new Label()
                {
                    Text = item.field1,
                };
                grid.Children.Add(field1_value, 0, 3);
                Grid.SetRowSpan(field1_value, 2);
                var field2_value = new Label()
                {
                    Text = item.field2,
                };
                grid.Children.Add(field2_value, 1, 3);
                Grid.SetRowSpan(field2_value, 2);
                int row_type1 = 3;
                int row_type2 = 3;
                foreach (var type_value in item.data)
                {
                    var type1_value = new Label()
                    {
                        Text = type_value.type1,
                    };
                    grid.Children.Add(type1_value, 2, row_type1);
                    var type2_value = new Label()
                    {
                        Text = type_value.type2,
                    };
                    grid.Children.Add(type2_value, 3, row_type2);
                    row_type1++;
                    row_type2++;
                }
            }
            Content = grid;
            //this.BindingContext = jsondata;
        }
    }
    public class Rootobject
    {
        public string field1 { get; set; }
        public string field2 { get; set; }
        public Datum[] data { get; set; }
    }
    public class Datum
    {
        public string type1 { get; set; }
        public string type2 { get; set; }
    }
    }
