    class Parameter : INotifyPropertyChanged //wrapper
    {
        private string _Value;
        public string Value //real value
        {
            get { return _Value; }
            set { _Value = value; RaisePropertyChanged("Value"); } 
        }
        public Parameter(string value)
        {
            Value = value;
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class ViewModel
    {
        public Dictionary<string, Parameter> Parameters
    }
    <ItemsControl ItemsSource="{Binding Path=Parameters, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Margin="3" >
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Label Grid.Column="0" Content="{Binding Path=Key}" Margin="3" />
                    <TextBox Grid.Column="1" Text="{Binding Path=Value.Value, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" IsReadOnly="True" Margin="3" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
