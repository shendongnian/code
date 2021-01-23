    public partial class MyDvcController : DialogViewController
	{
		public MyDvcController (UINavigationController nav): base (UITableViewStyle.Grouped, null)
		{
			navigation = nav;
			Root = new RootElement ("Demos"){
				new Section ("Element API"){
					new StringElement ("iPhone Settings Sample", DemoElementApi),
				
				}
			};
		}  
    }
