    public class RichTextBox : DependencyObject
    {
      #region DocumentSource attached property
    
      public static readonly DependencyProperty DocumentSourceProperty = DependencyProperty.RegisterAttached(
        "DocumentSource", 
        typeof(FlowDocument), 
        typeof(RichTextBox), 
        new PropertyMetadata(default(FlowDocument), RichTextBox.OnDocumentSourceChanged));
    
      public static void SetDocumentSource(DependencyObject attachingElement, FlowDocument value) => attachingElement.SetValue(RichTextBox.DocumentSourceProperty, value);
    
      public static FlowDocument GetDocumentSource(DependencyObject attachingElement) => (FlowDocument) attachingElement.GetValue(RichTextBox.DocumentSourceProperty);
    
      #endregion
    
      private static void OnDocumentSourceChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        if (!(attachingElement is System.Windows.Controls.RichTextBox richTextBox))
        {
          return;
        }
    
        richTextBox.Document = e.NewValue as FlowDocument;
      }
    }
