    void ClearTextBoxes(DependencyObject obj)
    {
        TextBox tb = obj as TextBox;
        if (tb != null)
            tb.Text = "";
    
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj as DependencyObject); i++)
            ClearTextBoxes(VisualTreeHelper.GetChild(obj, i));
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ClearTextBoxes(this);
    }
