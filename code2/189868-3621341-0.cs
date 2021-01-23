        protected override bool CommitCellEdit(FrameworkElement editingElement)
        {
            DatePicker dp = editingElement as DatePicker;
            DateTime dt;
            try
            {
                dt = Convert.ToDateTime(dp.Text);
                dp.SelectedDate = dt;
            }
            catch (FormatException)
            {
                dp.Text = String.Empty;
            }
           
            
            BindingExpression binding = editingElement.GetBindingExpression(DatePicker.SelectedDateProperty);
            if (binding != null)
                binding.UpdateSource();
            return true;
            //return base.CommitCellEdit(editingElement);
        }
