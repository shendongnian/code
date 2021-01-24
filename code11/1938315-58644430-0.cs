    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    ...
    public class TextBlockFormatter
    {
        public static readonly DependencyProperty FormattedTextProperty = DependencyProperty.RegisterAttached(
            "FormattedText",
            typeof(string),
            typeof(TextBlockFormatter),
            new FrameworkPropertyMetadata(null, OnFormattedTextChanged));
        public static void SetFormattedText(UIElement element, string value)
        {
            element.SetValue(FormattedTextProperty, value);
        }
        public static string GetFormattedText(UIElement element)
        {
            return (string)element.GetValue(FormattedTextProperty);
        }
        private static void OnFormattedTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textblock = (TextBlock)d;
            var formatted = (string)e.NewValue;
            if (string.IsNullOrEmpty(formatted))
                textblock.Text = "";
            else
            {
                textblock.Inlines.Clear();
                foreach (var item in FindRuns(formatted))
                {
                    var run = new Run(item.Text);
                    if (item.IsBold)
                        run.FontWeight = FontWeights.Bold;
                    textblock.Inlines.Add(run);
                }
            }
        }
        class FormattedRun
        {
            public string Text { get; set; }
            public bool IsBold { get; set; }
            public FormattedRun(string text, bool isBold = false)
            {
                Text = text;
                IsBold = isBold;
            }
        }
        static IEnumerable<FormattedRun> FindRuns(string s)
        {
            int position = 0;
            while (position < s.Length)
            {
                var starttag = s.IndexOf("<bold>", position, StringComparison.OrdinalIgnoreCase);
                if (starttag < 0)
                {
                    yield return new FormattedRun(s.Substring(position));
                    break;
                }
                else if (starttag > position)
                    yield return new FormattedRun(s.Substring(position, starttag - position));
                var endtag = s.IndexOf("</bold>", starttag + 6, StringComparison.OrdinalIgnoreCase);
                if (endtag < 0)
                {
                    yield return new FormattedRun(s.Substring(starttag + 6), isBold: true);
                    break;
                }
                yield return new FormattedRun(s.Substring(starttag + 6, endtag - starttag - 6), isBold: true);
                position = endtag + 7;
            }
        }
    }
