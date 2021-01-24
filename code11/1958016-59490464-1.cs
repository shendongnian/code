    //Code
    public partial class Page1 : ContentPage
    {
        public List<Person> list { get; set; }
        
        public Page1()
        {
            InitializeComponent();
            var list1 = new GoodsList() { new Goods { Name = "Apple" } , new Goods { Name = "Banana" } };
            list1.Name = "Fruits";
            var list2 = new GoodsList() { new Goods { Name = "Tomato" }, new Goods { Name = "Spinach" } };
            list2.Name = "Vegetables";
            var list3 = new GoodsList() { new Goods { Name = "Apple" }, new Goods { Name = "Orange" } };
            list3.Name = "Fruits";
            var list4 = new GoodsList() { new Goods { Name = "Onion" }, new Goods { Name = "Garlic" } };
            list4.Name = "Vegetables";
            list = new List<Person>();
            list.Add(new Person
            {
                Name = "P1",
                List = new List<GoodsList>() { list1,list2}
            }) ;
            list.Add(new Person
            {
                Name = "P2",
                List = new List<GoodsList>() { list3, list4}
            });
            this.BindingContext = this;
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.Navigation.PushAsync(new Page2(e.SelectedItem), true) ;
        }
    }
