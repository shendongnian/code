<Button Grid.Column="2" BindingContext="{Binding Source={x:Reference BillView}, Path=BindingContext}"   Command="{Binding YOUCOMMAND}"   CommandParameter="{Binding Source={x:Reference Item}, Path=BindingContext}"></Button>
                
And for your viewmodel try this,
 public ICommand YOUCOMMAND
        {
            get
            {
                return new Command((e) =>
                    {
                        // Your logic
                    });
            }
        }
Since you've used a list view and your commands are inside the DataTemplate, the binding is attached to the binding context of the each individual model in the ItemSource.
