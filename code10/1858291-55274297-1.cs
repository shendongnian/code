	public partial class GroupedListXaml : ContentPage
	{
		private ObservableCollection<GroupedOrderModel> grouped { get; set; }
		public GroupedListXaml ()
		{
			InitializeComponent ();
			grouped = new ObservableCollection<GroupedOrderModel> ();
			var person1Group = new GroupedOrderModel() { personName = "   john"};
			var person2Group = new GroupedOrderModel() { personName = "   alex"};
            var person3Group = new GroupedOrderModel() { personName = "   jack"};
            person1Group.Add (new OrderModel () { orderName = "   OrderOne"});
            person1Group.Add (new OrderModel() { orderName = "   OrderTwo" });
            person1Group.Add (new OrderModel() { orderName = "   OrderThree"});
            person1Group.Add (new OrderModel() { orderName = "   OrderFour"});
            person2Group.Add (new OrderModel() { orderName = "   OrderOne"});
            person2Group.Add (new OrderModel() { orderName = "   OrderTwo"});
            person2Group.Add (new OrderModel() { orderName = "   OrderThree"});
			grouped.Add (person1Group);
            grouped.Add (person2Group);
            //Person3 without OrderModel
            grouped.Add(person3Group);
			lstView.ItemsSource = grouped;
		}
	}
