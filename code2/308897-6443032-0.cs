    class MyCombo : ComboBox
        {
            // Keep track of the previous value
            int previousIndex = 0;
    
            // Determines whether the OnSelectedIndexChanged is ignored
            bool ignoreChangedEvent = false;
    
            /// <summary>
            /// Raises the <see cref="E:System.Windows.Forms.ComboBox.SelectedIndexChanged"/> event.
            /// </summary>
            /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
            protected override void OnSelectedIndexChanged(EventArgs e)
            {
                if (!ignoreChangedEvent)
                {
                    // Prompt the user to see if they really want to change.
                    if (MessageBox.Show("Change value?", Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        ignoreChangedEvent = true;
                        base.SelectedIndex = previousIndex;
                    }
                    else
                    {
                        previousIndex = base.SelectedIndex;
                    }
                }
                else
                {
                    ignoreChangedEvent = false;
                }
    
                base.OnSelectedIndexChanged(e);
            }
        }
