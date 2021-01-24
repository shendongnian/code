ContentView contentView = new ContentView
{
          Content = label
};
contentView.SizeChanged += OnContentViewSizeChanged;
and in the event
void OnContentViewSizeChanged(object sender, EventArgs args)
{
         string text = "Is this question similar to what you get asked at work? Learn more about asking and sharing private information with your coworkers using Stack Overflow for Teams. Is this question similar to what you get asked at work? Learn more about asking and sharing private information with your coworkers using Stack Overflow for Teams.";
         View view = (View)sender;
         // Line height is 1.2 if it's iOS or Android, but 1.3 for UWP
         double lineHeight = 1.3;
         double charWidth = 0.5;
         text = String.Format(text, lineHeight, charWidth, view.Width, view.Height);
         int charCount = text.Length;
         int fontSize = (int)Math.Sqrt(view.Width * view.Height / (charCount * lineHeight * charWidth));
         int lineCount = (int)(view.Height / (lineHeight * fontSize));
         int charsPerLine = (int)(view.Width / (charWidth * fontSize));
         label.Text = text;
         label.FontSize = fontSize;
}
Here's some [official documentation][1] that recommends it
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/creating-mobile-apps-xamarin-forms/summaries/chapter05#empirically-fitting-text
