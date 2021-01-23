        class RectangleAdorner : Adorner
        {
            public RectangleAdorner(TextBox textbox)
                : base(textbox)
            {
                textbox.TextChanged += delegate
                {
                    textbox.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate
                    {
                        SignalInvalidate()
                    });
                };
            }
            void SignalInvalidate()
            {
                TextBox box = (TextBox)this.AdornedElement;
                box.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)InvalidateVisual);
            }
            // ...
        }
