        private IVsWindowFrame GetWindow()
        {
            var window = (ToolWindowPane)parent.GetIVsWindowPane();
            return (IVsWindowFrame)window.Frame;
        }
        private void DoShow()
        {
            var window = GetWindow();
            var textViewOrigin = (activeWpfTextView as UIElement).PointToScreen(new Point(0, 0));
            var caretPos = activeWpfTextView.Caret.Position.BufferPosition;
            var charBounds = activeWpfTextView
                .GetTextViewLineContainingBufferPosition(caretPos)
                .GetCharacterBounds(caretPos);
            double textBottom = charBounds.Bottom;
            double textX = charBounds.Right;
            Guid guid = default(Guid);
            double newLeft = textViewOrigin.X + textX;
            double newTop = textViewOrigin.Y + textBottom - activeWpfTextView.ViewportTop;
            window.SetFramePos(VSSETFRAMEPOS.SFP_fMove, ref guid,
                (int)newLeft, (int)newTop,
                0, 0);
            window.Show();
            resultsList.Focus();
        }
