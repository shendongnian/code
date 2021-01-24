     <StackLayout>
            <ListView x:Name="listview1" ItemsSource="{Binding persons}">
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Id}" />
                                <Label Text="{Binding name}" />
                                <Button
                                    Command="{Binding BindingContext.command, Source={x:Reference listview1}}"
                                    CommandParameter="{Binding Id}"
                                    Text="Delete item" />
                            </StackLayout>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    	public partial class Page1 : ContentPage
	{
        public ObservableCollection<person> persons { get; set; }
        public RelayCommand1 command { get; set; }
        public Page1 ()
		{
			InitializeComponent ();
            persons = new ObservableCollection<person>();
            
            for(int i =0;i<20;i++)
            {
                person p = new person()
                {
                    Id = i,
                    name = "cherry" + i
                };
                persons.Add(p);
                command = new RelayCommand1(obj => method1((int)obj));
            }
            this.BindingContext = this;
        }
        public void method1(int Id)
        {
            persons.RemoveAt(Id);
            //IEnumerable<person> list = persons.Where(x => x.Id == Id);
            //foreach (person m in list)
            //{
                
            //}
        }
    }
    public class person
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
