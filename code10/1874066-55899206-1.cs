    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page21 : ContentPage
	{
		public Page21 ()
		{
			InitializeComponent ();
            Title = "Name"; // here need show NAME - I can't display my name here
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry, // here NAME is shown
                }
            };
        }
        private void btn1_Clicked(object sender, EventArgs e)
        {
            var data = this.BindingContext as TodoItem1;
            Console.WriteLine(data.Id);
            Console.WriteLine(data.Name);
        }
    }
