     public static void OnDocumentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var rtb = (RichTextBox)obj;
            if (args.NewValue != null)
            {
               
                var doc = (FlowDocument) args.NewValue;
                if (doc.Tag is RichTextBox)
                {
                    // clear belongs to another rtb.
                    ((RichTextBox) doc.Tag).Document = new FlowDocument();
                }
                else
                {
                    doc.Tag = rtb;
                }
                rtb.Document =doc;
            }
        }
