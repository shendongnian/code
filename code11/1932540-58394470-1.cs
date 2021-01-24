    public class CustomTemplateColumn : DataGridTemplateColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            FrameworkElement fe = base.GenerateElement(cell, dataItem);
            if (fe != null)
                fe.KeyDown += OnKeyDown;
            return fe;
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            DataGridOwner.BeginEdit();
        }
    }
