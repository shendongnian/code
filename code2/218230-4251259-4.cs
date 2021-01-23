    public class MyDataGridHelper : DependencyObject 
    {
        private static readonly DependencyProperty TextColumnStyleProperty = DependencyProperty.RegisterAttached(
            "TextColumnStyle",
            typeof(Style),
            typeof(MyDataGridHelper),
            new PropertyMetadata(MyPropertyChangedCallback));
        public static void SetTextColumnStyle(DependencyObject element, string value)
        {
            element.SetValue(TextColumnStyleProperty, value);
        }
        public static Style GetTextColumnStyle(DependencyObject element)
        {
            return (Style)element.GetValue(TextColumnStyleProperty);
        }
        private static void MyPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d) == true)
            {
                return;
            }
            DataGridTextColumn textColumn = (DataGridTextColumn)d;
            Style textColumnStyle = e.NewValue as Style;
            foreach (SetterBase setterBase in textColumnStyle.Setters)
            {
                if (setterBase is Setter)
                {
                    Setter setter = setterBase as Setter;
                    if (setter.Value is BindingBase)
                    {
                        //Not done yet..
                    }
                    else
                    {
                        Type type = textColumn.GetType();
                        PropertyInfo propertyInfo = type.GetProperty(setter.Property.Name);
                        propertyInfo.SetValue(textColumn, setter.Value, null);
                    }
                }
            }
        }
    }
