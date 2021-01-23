    public class ComboBoxDisableUndoBehavoir : Behavior<ComboBox>
    {
        public ComboBoxDisableUndoBehavoir()
        {
        }
        protected override void OnAttached()
        {
            if (AssociatedObject != null)
            {
                AssociatedObject.Loaded += AssociatedObject_Loaded;
            }
            base.OnAttached();
        }
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var tb = AssociatedObject.Template.FindName("PART_EditableTextBox", AssociatedObject) as TextBox;
            if (tb != null)
            {
                tb.IsUndoEnabled = false;
            }
        }
    }
