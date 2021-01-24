    private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
    {
      DependencyObject cellItemContainer = this.datagrid.ItemContainerGenerator.ContainerFromItem(
        (this.datagrid.CurrentCell.Item as SomethingItem));
    
      // If the current cell has validation errors find the edit TextBox child control
      if (Validation.GetHasError(cellItemContainer) && TryFindChildElement(cellItemContainer, out TextBox editTextBox))
      {
        // Get the property name of he binding source
        var propertyName = (editTextBox.BindingGroup.BindingExpressions.FirstOrDefault() as BindingExpression)?.ResolvedSourcePropertyName ?? string.Empty;
    
        // Use reflection to get the value of the binding source
        object value = this.datagrid.CurrentCell.Item.GetType().GetProperty(propertyName).GetValue(this.datagrid.CurrentCell.Item);
    
        // Check which ToString() to invoke
        editTextBox.Text = value is DateTime date 
          ? date.ToShortDateString() 
          : value.ToString();
    
        // Trigger validation and define which cell to cancel the edit
        // This is required because the edit TexBox lost focus
        Keyboard.Focus(editTextBox);
      }
      this.datagrid.CancelEdit();
    }
    // Traverses the visual tree to find a child element of type TElement
    private bool TryFindVisualChild<TChild>(DependencyObject parent, out TChild resultElement) where TChild : DependencyObject
    {
      resultElement = null;
      for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
      {
        DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);
        if (childElement is Popup popup)
        {
          childElement = popup.Child;
        }
        if (childElement is TChild)
        {
          resultElement = childElement as TChild;
          return true;
        }
        if (TryFindVisualChild(childElement, out resultElement))
        {
          return true;
        }
      }
      return false;
    }
