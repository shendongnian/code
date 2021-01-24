    /// <summary>Adjust font in case autosize.</summary>
    private float GetFontSize(PdfArray bBox, String value) {
        if (this.fontSize == 0) {
            //We do not support autosize with multiline.
            if (IsMultiline() || bBox == null || value == null || String.IsNullOrEmpty(value)) {
                return DEFAULT_FONT_SIZE;
            }
            else {
                return Math.Max(ApproximateFontSizeToFitBBox(this.font, bBox.ToRectangle(), value), MIN_FONT_SIZE);
            }
        }
        return this.fontSize;
    }
