         // Disable editing of protected text (=UltraCondensed FontStretch)
            if (!(e.Key == Key.Left | e.Key == Key.Right | e.Key == Key.Up | e.Key == Key.Down | e.Key == Key.LeftShift))
            {
                var trange = new TextRange(Dox.Selection.Start, Dox.Selection.End);
                bool isProtected = false;
                switch (trange.Text.Length)
                {
                    case 0:
                        {
                            // Zero length selection
                            if (e.Key == Key.Back)
                                trange = new TextRange(trange.Start.GetNextInsertionPosition(LogicalDirection.Backward).GetInsertionPosition(LogicalDirection.Forward), trange.Start);
                            else if (e.Key == Key.Delete)
                                trange = new TextRange(trange.End.GetInsertionPosition(LogicalDirection.Forward), trange.End.GetNextInsertionPosition(LogicalDirection.Forward));
                            isProtected = trange.GetPropertyValue(FontStretchProperty) == FontStretches.UltraCondensed;
                            break;
                        }
        
                    default:
                        {
    //RichTextBox selection has length
                            
    isProtected = trange.GetPropertyValue(FontStretchProperty) == DependencyProperty.UnsetValue || trange.GetPropertyValue(FontStretchProperty) == FontStretches.UltraCondensed;
                            break;
                        }
                }
    
                if (isProtected)
                {
                    e.Handled = true; return;
                }
            }
