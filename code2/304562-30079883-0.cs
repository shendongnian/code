    public class ToolTipTextBlock : TextBlock
       {
          protected override void OnToolTipOpening(ToolTipEventArgs e)
          {
             if (TextTrimming != TextTrimming.None)
             {
               e.Handled = !IsTextTrimmed();
             }
          }
    
          private bool IsTextTrimmed()
          {
             var typeface = new Typeface(FontFamily, FontStyle, FontWeight, FontStretch);
             var formattedText = new FormattedText(Text, CultureInfo.CurrentCulture, FlowDirection, typeface, FontSize, Foreground);
             return formattedText.Width > ActualWidth;
          }
       }
