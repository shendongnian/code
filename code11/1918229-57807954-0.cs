    public class CustomComboBoxColumn : System.Windows.Controls.DataGridComboBoxColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement fe = base.GenerateElement(cell, dataItem);
            if (fe is Control control)
                control.Margin = new Thickness(4, 2, 4, 2);
            return fe;
        }
    }
