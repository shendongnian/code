    private void ChangeFontStyleForSelectedText(string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            _maskChanges = true;
            try
            {
                int txtStartPosition = txtFunctionality.SelectionStart;
                int selectionLength = txtFunctionality.SelectionLength;
                if (selectionLength > 0)
                    using (RichTextBox txtTemp = new RichTextBox())
                    {
                        txtTemp.Rtf = txtFunctionality.SelectedRtf;
                        for (int i = 0; i < selectionLength; ++i)
                        {
                            txtTemp.Select(i, 1);
                            txtTemp.SelectionFont = RenderFont(txtTemp.SelectionFont, familyName, emSize, fontStyle, enableFontStyle);
                        }
 
                        txtTemp.Select(0, selectionLength);
                        txtFunctionality.SelectedRtf = txtTemp.SelectedRtf;
                        txtFunctionality.Select(txtStartPosition, selectionLength);
                    }
            }
            finally
            {
                _maskChanges = false;
            }
        }
