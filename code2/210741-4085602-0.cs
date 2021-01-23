    public class ActiveTextBox:TextBox
        {
            public ActiveTextBox()
            {
                Loaded += ActiveTextBox_Loaded;
            }
    
            void ActiveTextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
            {
                Binding myBinding = BindingOperations.GetBinding(this, TextProperty);
                if (myBinding != null && myBinding.UpdateSourceTrigger != UpdateSourceTrigger.PropertyChanged)
                {
                    Binding bind = (Binding) Allkort3.Common.Extensions.Extensions.CloneProperties(myBinding);
                    bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                    BindingOperations.SetBinding(this, TextBox.TextProperty, bind);
                }
            }
        }
