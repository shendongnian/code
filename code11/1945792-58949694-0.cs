    public class SearchComboBox : ComboBox
    {
        TextBox editableTextBox;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            editableTextBox = GetTemplateChild("PART_EditableTextBox") as TextBox;
            editableTextBox.TextChanged += EditableTextBox_TextChanged;
        }
        private void EditableTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ICollectionView ICV = ItemsSource as ICollectionView;
            if(ICV != null)
            {
                if (string.IsNullOrEmpty(editableTextBox.Text.Trim()))
                    ICV.Filter = null;
                else
                    ICV.Filter = new Predicate<object>(i => ((Equipment)i).equipmentLabel.Contains(editableTextBox.Text));
                IsDropDownOpen = true;
            }
        }
    }
