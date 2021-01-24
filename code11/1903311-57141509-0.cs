    public partial class UserTable : ContentView
	{
		public ObservableCollection<Patient> Users
		{
			get
			{
				return (ObservableCollection<Patient>)GetValue(UsersProperty);
			}
			set
			{
				SetValue(UsersProperty, value);
			}
		}
		public static readonly BindableProperty UsersProperty =
			BindableProperty.Create("Users", typeof(ObservableCollection<Patient>), typeof(UserTable), null,
				BindingMode.Default, null, OnItemsSourceChanged);
		public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create(
			propertyName: nameof(ItemSelectedCommand),
			returnType: typeof(ICommand),
			declaringType: typeof(UserTable),
			defaultValue: null);
		public ICommand ItemSelectedCommand
		{
			get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
			set { SetValue(ItemSelectedCommandProperty, value); }
		}
		static void OnItemsSourceChanged(BindableObject bindable, object oldvalue, object newvalue)
		{
			System.Diagnostics.Debug.WriteLine("source changed");
		}
		public UserTable()
		{
			InitializeComponent();
		}
    }
Then in Xaml you can either use [EventToCommandBehaviour](https://developer.xamarin.com/samples/xamarin-forms/Behaviors/EventToCommandBehavior/) by adding 
    <ListView.Behaviors>
        <behaviors:EventToCommandBehavior EventName="ItemSelected" Command="{Binding Source={x:Reference this},Path=ItemSelectedCommand}"/>
    </ListView.Behaviors>
or you can create your own `CustomListView` (that inherites from ListView) that has ItemSelected in it like in this [example](https://github.com/lubiepomaranczki/XamForms.Enhanced/blob/develop/XamForms.Enhanced.Abstractions/Views/ExtendedListView.cs)
 2. Second approach is that instead of creating a control with `ListView` you can create a data template. [Here](https://docs.microsoft.com/pl-pl/xamarin/xamarin-forms/app-fundamentals/templates/data-templates/creating) you have documentation on how to do it. 
If you ask for my opinion, I would say go with second approach - later you can reuse that View in other places.
 
