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
          /// <summary>
        /// Changes a font from originalFont appending other properties
        /// </summary>
        /// <param name="originalFont">Original font of text</param>
        /// <param name="familyName">Target family name</param>
        /// <param name="emSize">Target text Size</param>
        /// <param name="fontStyle">Target font style</param>
        /// <param name="enableFontStyle">true when enable false when disable</param>
        /// <returns>A new font with all provided properties added/removed to original font</returns>
        private Font RenderFont(Font originalFont, string familyName, float? emSize, FontStyle? fontStyle, bool? enableFontStyle)
        {
            if (fontStyle.HasValue && fontStyle != FontStyle.Regular && fontStyle != FontStyle.Bold && fontStyle != FontStyle.Italic && fontStyle != FontStyle.Underline)
                throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyleForSelectedText");
            Font newFont;
            FontStyle? newStyle = null;
            if (fontStyle.HasValue)
            {
                if (fontStyle.HasValue && fontStyle == FontStyle.Regular)
                    newStyle = fontStyle.Value;
                else if (originalFont != null && enableFontStyle.HasValue && enableFontStyle.Value)
                    newStyle = originalFont.Style | fontStyle.Value;
                else
                    newStyle = originalFont.Style & ~fontStyle.Value;
            }
            newFont = new Font(!string.IsNullOrEmpty(familyName) ? familyName : originalFont.FontFamily.Name,
                                emSize.HasValue ? emSize.Value : originalFont.Size,
                                newStyle.HasValue ? newStyle.Value : originalFont.Style);
            return newFont;
        }
