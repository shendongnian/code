        public class MyListBox : ListBox
        {
            //// Static constructor to override.
            static MyListBox()
            {
                  ListBox.ItemsSourceProperty.OverrideMetadata(typeof(MyListBox), new FrameworkPropertyMetadata(null, MyListBoxItemsSourceChanged));
            }
            private static void MyListBoxItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                 var myListBox = sender as MyListBox;
                 //// You custom code.
            }
        } 
