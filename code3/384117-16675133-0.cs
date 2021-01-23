    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.ComboBox.SelectionChangeCommitted"/> event _after_ forcing any data bindings to be updated.
    ''' </summary>
    ''' <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
    Protected Overrides Sub OnSelectionChangeCommitted(e As EventArgs)
        Dim bindings As List(Of Binding) = ( _
            From x In Me.DataBindings.Cast(Of Binding)()
            Where (x.PropertyName = "SelectedItem" OrElse x.PropertyName = "SelectedValue" OrElse x.PropertyName = "SelectedIndex") AndAlso
                  (x.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged OrElse x.DataSourceUpdateMode = DataSourceUpdateMode.OnValidation)
        ).ToList()
    
        For Each b As Binding In bindings
            ' Force the binding to update from the new SelectedItem
            b.WriteValue()
            ' Force the Textbox to update from the binding
            b.ReadValue()
        Next
    
        MyBase.OnSelectionChangeCommitted(e)
    End Sub
