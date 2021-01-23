    /// <summary>
    /// Class for text manipulation operations
    /// </summary>
    public class TextManipulation
    {
        /// <summary>
        /// Is manipulating a specific string inside of a TextPointer Range (TextBlock, TextBox...)
        /// </summary>
        /// <param name="startPointer">Starting point where to look</param>
        /// <param name="endPointer">Endpoint where to look</param>
        /// <param name="keyword">This is the string you want to manipulate</param>
        /// <param name="fontStyle">The new FontStyle</param>
        /// <param name="fontWeight">The new FontWeight</param>
        /// <param name="fontSize">The new FontSize</param>
        public static void FromTextPointer(TextPointer startPointer, TextPointer endPointer, string keyword, FontStyle fontStyle, FontWeight fontWeight, double fontSize)
        {
            FromTextPointer(startPointer, endPointer, keyword, fontStyle, fontWeight, fontSize, null);
        }
        /// <summary>
        /// Is manipulating a specific string inside of a TextPointer Range (TextBlock, TextBox...)
        /// </summary>
        /// <param name="startPointer">Starting point where to look</param>
        /// <param name="endPointer">Endpoint where to look</param>
        /// <param name="keyword">This is the string you want to manipulate</param>
        /// <param name="fontStyle">The new FontStyle</param>
        /// <param name="fontWeight">The new FontWeight</param>
        /// <param name="fontSize">The new FontSize</param>
        /// <param name="newString">The New String (if you want to replace, can be null)</param>
        public static void FromTextPointer(TextPointer startPointer, TextPointer endPointer, string keyword, FontStyle fontStyle, FontWeight fontWeight, double fontSize, string newString)
        {
            if(startPointer == null)throw new ArgumentNullException(nameof(startPointer));
            if(endPointer == null)throw new ArgumentNullException(nameof(endPointer));
            if(string.IsNullOrEmpty(keyword))throw new ArgumentNullException(keyword);
            TextRange text = new TextRange(startPointer, endPointer);
            TextPointer current = text.Start.GetInsertionPosition(LogicalDirection.Forward);
            while (current != null)
            {
                string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                if (!string.IsNullOrWhiteSpace(textInRun))
                {
                    int index = textInRun.IndexOf(keyword);
                    if (index != -1)
                    {
                        TextPointer selectionStart = current.GetPositionAtOffset(index,LogicalDirection.Forward);
                        TextPointer selectionEnd = selectionStart.GetPositionAtOffset(keyword.Length,LogicalDirection.Forward);
                        TextRange selection = new TextRange(selectionStart, selectionEnd);
                        if(!string.IsNullOrEmpty(newString))
                            selection.Text = newString;
                        
                        selection.ApplyPropertyValue(TextElement.FontSizeProperty, fontSize);
                        selection.ApplyPropertyValue(TextElement.FontStyleProperty, fontStyle);
                        selection.ApplyPropertyValue(TextElement.FontWeightProperty, fontWeight);
                    }
                }
                current = current.GetNextContextPosition(LogicalDirection.Forward);
            }
        }
    }
