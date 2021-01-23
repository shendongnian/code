    public static class TextBoxExtension
    {
        public static int NumberOfVisibleChars(this textBox textBox)
        {
            int count = 0;
            do {
                count++;
                var testString = new string('X', count);
                var stringWidth = System.Drawing.Graphics.MeasureString(testString, textBox.Font);                
            } while (stringWidth < textBox.Width);
            
            if (stringWidth == textBox.Width) 
                return count;
            else
                return count-1;
        }
    }
