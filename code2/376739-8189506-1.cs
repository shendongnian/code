    using Microsoft.Phone.Controls.Primitives;
    delegate void ChildProc(DependencyObject o);
    // applies the delegate proc to all children of a given type
    private void DoForChildrenRecursively(DependencyObject o, Type typeFilter, ChildProc proc)
    {
        // check that we got a child of right type
        if (o.GetType() == typeFilter)
        {
            proc(o);
        }
        // recursion: dive one level deeper into the child hierarchy
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
        {
            DoForChildrenRecursively(VisualTreeHelper.GetChild(o, i), typeFilter, proc);
        }
    }
    // applies the given font size to the pivot's header items and adjusts the height of the header area
    private void AdjustPivotHeaderFontSize(Pivot pivot, double fontSize)
    {
        double lastFontSize = fontSize;
        DoForChildrenRecursively(pivot, typeof(PivotHeaderItem), (o) => { lastFontSize = ((PivotHeaderItem)o).FontSize; ((PivotHeaderItem)o).FontSize = fontSize; });
        // adjust the header control height according to font size change
        DoForChildrenRecursively(pivot, typeof(PivotHeadersControl), (o) => { ((PivotHeadersControl)o).Height -= (lastFontSize - fontSize) * 1.33; });
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        // make header items having FontSize == PhoneFontSizeLarge
        AdjustPivotHeaderFontSize(pivot, (double)Resources["PhoneFontSizeLarge"]);
    }
