    /// <summary>
    /// A modification of the standard <see cref="ComboBox"/> in which a data binding
    /// on the SelectedItem property with the update mode set to DataSourceUpdateMode.OnPropertyChanged
    /// actually updates when a selection is made in the combobox.
    /// </summary>
    public class BindableComboBox : ComboBox
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.ComboBox.SelectionChangeCommitted"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            base.OnSelectionChangeCommitted(e);
            var bindings = this.DataBindings
                .Cast<Binding>()
                .Where(x => 
                    x.PropertyName == "SelectedItem" && 
                    x.DataSourceUpdateMode == DataSourceUpdateMode.OnPropertyChanged);
            foreach (var binding in bindings)
            {
                // Force the binding to update from the new SelectedItem
                binding.WriteValue();
                // Force the Textbox to update from the binding
                binding.ReadValue();
            }
        }
    }
