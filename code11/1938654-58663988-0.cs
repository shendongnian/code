private void HighlightText(object controlToHighlight, string textToHighlight)
{
    if (controlToHighlight == null) return;
    if (controlToHighlight is TextBlock tb)
    {
        var regex = new Regex("(" + textToHighlight + ")", RegexOptions.IgnoreCase);
            
        if (textToHighlight.Length == 0)
        {
            var str = tb.Text;
            tb.Inlines.Clear();
            tb.Inlines.Add(str);
            return;
        }
            
        var substrings = regex.Split(tb.Text);
        tb.Inlines.Clear();
            
        foreach (var item in substrings)
        {
            if (regex.Match(item).Success)
            {
                var run = new Run(item)
                {
                    Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#FFFFF45E")
                };
                tb.Inlines.Add(run);                            
            }
            else
            {
                tb.Inlines.Add(item);
            }
        }
    }
    else
    {
        if (!(controlToHighlight is DependencyObject dependencyObject)) return;
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
        {
            HighlightText(VisualTreeHelper.GetChild(dependencyObject, i), textToHighlight);
        }
    }
}
I hope this is helpful!
  [1]: https://www.codeproject.com/Articles/103259/Highlight-Searched-Text-in-WPF-ListView
