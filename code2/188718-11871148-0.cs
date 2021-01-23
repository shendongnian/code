    public partial class Window1 : Window
    {
        public Window1()
        {
            MyString = "Here is my string";
        }
        public string MyString
        {
            get;
            set;
        }
    }
        <Button Content="Test Button" Tag="{Binding RelativeSource={RelativeSource AncestorType={x:Type Window}}}">
            <Button.ContextMenu>
                <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}" >
                    <MenuItem Header="{Binding MyString}"/>
                </ContextMenu>
            </Button.ContextMenu>
        </Button>
