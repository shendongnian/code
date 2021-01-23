        class RectangleAdorner : Adorner
        {
            public RectangleAdorner(RichTextBox textbox)
                : base(textbox)
            {
                textbox.TextChanged += delegate
                {
                    SignalInvalidate();
                };
            }
            void SignalInvalidate()
            {
                TextBox box = (RichTextBox)this.AdornedElement;
                box.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)InvalidateVisual);
            }
            // ...
        }
