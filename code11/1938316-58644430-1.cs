    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Xml.Linq;
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
                try
                {
                    var nodeStack = new Stack<StyleStackNode>();
                    var root = XElement.Parse("<root>" + formatted + "</root>");
                    nodeStack.Push(new StyleStackNode(root.FirstNode));
                    while (nodeStack.Count > 0)
                    {
                        var format = nodeStack.Pop();
                        if (format.Node.NextNode != null)
                            nodeStack.Push(new StyleStackNode(format.Node.NextNode, copyFormats: format.Formatters));
                        if (format.Node is XElement tag && tag.FirstNode != null)
                        {
                            var adding = new StyleStackNode(tag.FirstNode, copyFormats: format.Formatters);
                            if (0 == string.Compare(tag.Name.LocalName, "bold", true))
                                adding.Formatters.Add(run => run.FontWeight = FontWeights.Bold);
                            else if (0 == string.Compare(tag.Name.LocalName, "italic", true))
                                adding.Formatters.Add(run => run.FontStyle = FontStyles.Italic);
                            nodeStack.Push(adding);
                        }
                        else if (format.Node is XText textNode)
                        {
                            var run = new Run();
                            foreach (var formatter in format.Formatters)
                                formatter(run);
                            run.Text = textNode.Value;
                            textblock.Inlines.Add(run);
                        }
                    }
                }
                catch
                {
                    textblock.Text = formatted;
                }
            }
        }
        class StyleStackNode
        {
            public XNode Node;
            public List<Action<Run>> Formatters = new List<Action<Run>>();
            public StyleStackNode(XNode node, IEnumerable<Action<Run>> copyFormats = null)
            {
                Node = node;
                if (copyFormats != null)
                    Formatters.AddRange(copyFormats);
            }
        }
    }
