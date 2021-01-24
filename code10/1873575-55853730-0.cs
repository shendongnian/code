    public class DataGridRadioButtonColumn : DataGridBoundColumn
    {
        private Dictionary<DataGridCell, RadioButton> _buttons = new Dictionary<DataGridCell, RadioButton>();
        private Dictionary<RadioButton, dynamic> _models = new Dictionary<RadioButton, dynamic>();
        public string Group { get; set; }
        public static readonly DependencyProperty GroupProperty = RadioButton.GroupNameProperty.AddOwner(
            typeof(DataGridRadioButtonColumn), new FrameworkPropertyMetadata("Group1"));
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            if (_buttons.ContainsKey(cell))
            {
                return (_buttons[cell]);
            }
            var radioButton = new RadioButton { GroupName = Group };
            radioButton.Unchecked += RadioButton_Unchecked;
            BindingOperations.SetBinding(radioButton, ToggleButton.IsCheckedProperty, Binding);
            _buttons.Add(cell, radioButton);
            _models.Add(radioButton, dataItem);
            return radioButton;
        }
        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            dynamic model = _models[button];
            try
            {
                model.Edited = true;
            }
            catch { }
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
           return _buttons[cell];
        }
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            var radioButton = editingElement as RadioButton;
            if (radioButton == null) return null;
            return radioButton.IsChecked;
        }
    }
