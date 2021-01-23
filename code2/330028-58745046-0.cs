    public class DataGridCustomComboBoxColumn : DataGridComboBoxColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            return base.GenerateEditingElement(cell, dataItem);
        }
    }
