     <Label HorizontalOptions="CenterAndExpand" Text="Welcome to Xamarin.Forms!">
                <Label.GestureRecognizers>
                    <TapGestureRecognizer
                        Command="{Binding command1}"
                        CommandParameter="55"
                        NumberOfTapsRequired="1" />
                </Label.GestureRecognizers>
            </Label>
    public partial class Page20 : ContentPage
	{
        public RelayCommand1 command1 { get; set; }
       
		public Page20 ()
		{
			InitializeComponent ();
            command1 = new RelayCommand1(obj => ChangeToTappedDate((string)obj));
            
            this.BindingContext = this;
		}
        public void ChangeToTappedDate(string position)
        {
            int value = int.Parse(position);
            Console.WriteLine("the position is {0}",value);
        }
    }
