        private void MoveCustomCaret()
        {
            var caretLocation = txtName.GetRectFromCharacterIndex(txtName.CaretIndex).Location;
            if (!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(Caret, caretLocation.X);
            }
            if (!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(Caret, caretLocation.Y);
            }
        }
