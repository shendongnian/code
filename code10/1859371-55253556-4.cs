    public class SomeClass : INotifyPropertyChanged
    {
        public SomeClass() {}
    
    private string selectedItem;
        public string SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                GetFormNames(this.SelectedItem);
            }
        }
    
        ...
    }
    <ToolBarPanel x:Name="myToolStripName" DataContext="{StaticResource MyClass}">
        <ToolBarTray>
            <ToolBar Height="25px">
                <ComboBox x:Name="cboCategories"
                          ItemsSource="{Binding Path=Categories}"
                          SelectedItem="{Binding SelectedItem, Mode=TwoWay}" />
                <ComboBox x:Name="cboForms"
                          ItemsSource="{Binding Path=Forms}" />
            </ToolBar>
        </ToolBarTray>
    </ToolBarPanel>
