        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            if (_buttons.ContainsKey(cell))
            {
                return (_buttons[cell]);
            }
            var radioButton = new RadioButton { GroupName = Group };
            radioButton.Unchecked += RadioButton_Unchecked; // Added
            BindingOperations.SetBinding(radioButton, ToggleButton.IsCheckedProperty, Binding);
            _buttons.Add(cell, radioButton);
            _models.Add(radioButton, dataItem); // Added
            return radioButton;
        }
