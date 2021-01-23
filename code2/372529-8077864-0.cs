    public class TabInsertBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        /// Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.KeyDown += textBox_KeyDown;
        }
        private const string Tab = "    ";
        public static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (e.Key == Key.Tab)
            {
                int selectionStart = textBox.SelectionStart;
                textBox.Text = String.Format("{0}{1}{2}",
                        textBox.Text.Substring(0, textBox.SelectionStart),
                        Tab,
                        textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength, (textBox.Text.Length) - (textBox.SelectionStart + textBox.SelectionLength))
                        );
                e.Handled = true;
                textBox.SelectionStart = selectionStart + Tab.Length;
            }
        } 
        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        /// Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.KeyDown -= textBox_KeyDown;
        }
    }
