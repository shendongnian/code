    public class MyListBox : ListBox
    {
        static MyListBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(MyListBox),
                new FrameworkPropertyMetadata(typeof(MyListBox)));
        }
    }
