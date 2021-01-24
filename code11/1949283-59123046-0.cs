    public class DataGridComboBoxColumnWithBindingHack : DataGridComboBoxColumn
    {
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement element = base.GenerateEditingElement(cell, dataItem);
            CopyItemsSource(element);
            return element;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement element = base.GenerateElement(cell, dataItem);
            CopyItemsSource(element);
            return element;
        }
        private void CopyItemsSource(FrameworkElement element)
        {
            BindingOperations.SetBinding(element, ComboBox.ItemsSourceProperty,
              BindingOperations.GetBinding(this, ComboBox.ItemsSourceProperty));
        }
    }
 <Commons:DataGridComboBoxColumnWithBindingHack 
                    Header="Header"
                    Width="*"
                    Visibility="{Binding SelectedType, Converter={Commons:ProfileVisibilityConverter}}"
                    ItemsSource="{Binding PotentialReinforces}"
                    SelectedValueBinding="{Binding ReinforceID, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"
                    DisplayMemberPath="Name"
                    SelectedValuePath="SectionID"/>
  [1]: http://joemorrison.org/blog/2009/02/17/excedrin-headache-35401281-using-combo-boxes-with-the-wpf-datagrid/
