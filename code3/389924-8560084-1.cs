    /// <summary>
    /// QbName
    /// </summary>
    public class QbName : DependencyObject
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached(
            "Name",
            typeof(string),
            typeof(QbName),
            new PropertyMetadata("")
            );
        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetName(DependencyObject element, string value)
        {
            element.SetValue(NameProperty, value);
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static string GetName(DependencyObject element)
        {
            return element.GetValue(NameProperty).ToString();
        }
    }
