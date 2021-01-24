    private void CancelChangesButton_Click(object sender, RoutedEventArgs e)
    {
      DependencyObject cellItemContainer = this.datagrid.ItemContainerGenerator.ContainerFromItem(
        (this.datagrid.CurrentCell.Item as SomethingItem));
    
      // If the current cell has validation errors find the edit TextBox child control
      if (Validation.GetHasError(cellItemContainer) && TryFindCildElement(cellItemContainer, out TextBox editTextBox))
      {
        // Get the property name of he binding source
        var propertyName = (editTextBox.BindingGroup.BindingExpressions.FirstOrDefault() as BindingExpression)?.ResolvedSourcePropertyName;
    
        // Use reflection to get the value of the binding source
        object value = this.datagrid.CurrentCell.Item.GetType().GetProperty(propertyName).GetValue(this.datagrid.CurrentCell.Item);
    
        // Check which ToString() to invoke
        editTextBox.Text = value is DateTime date 
          ? date.ToShortDateString() 
          : value.ToString();
    
        // Trigger validation
        Keyboard.Focus(editTextBox);
      }
      this.datagrid.CancelEdit();
    }
    // Traverses the visual tree to find a child element of type TElement
    private bool TryFindChildElement<TElement>(DependencyObject parent, out TElement resultElement) where TElement : DependencyObject
    {
      resultElement = null;
      for (var childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(parent); childIndex++)
      {
        DependencyObject childElement = VisualTreeHelper.GetChild(parent, childIndex);
        if (childElement is Popup popup)
        {
          childElement = popup.Child;
        }
        if (childElement is TElement)
        {
          resultElement = childElement as TElement;
          return true;
        }
        if (TryFindCildElement(childElement, out resultElement))
        {
          return true;
        }
      }
      return false;
    }
