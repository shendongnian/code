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
                RichTextBox box = (RichTextBox)this.AdornedElement;
                box.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)InvalidateVisual);
            }
            // ...
        }
