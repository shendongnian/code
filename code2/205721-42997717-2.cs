        public static List<string> WrapText(string text, double pixels, string fontFamily, float emSize)
        {
            string[] originalWords = text.Split(new string[] { " " },
                StringSplitOptions.None);
            List<string> wrappedLines = new List<string>();
            StringBuilder actualLine = new StringBuilder();
            double actualWidth = 0;
            foreach (string word in originalWords)
            {
                string wordWithSpace = word + " ";
                FormattedText formattedWord = new FormattedText(wordWithSpace,
                    CultureInfo.CurrentCulture,
                    System.Windows.FlowDirection.LeftToRight,
                    new Typeface(fontFamily), emSize, System.Windows.Media.Brushes.Black);
                actualLine.Append(wordWithSpace);
                actualWidth += formattedWord.Width;
                if (actualWidth > pixels)
                {
                    actualLine.Remove(actualLine.Length - wordWithSpace.Length, wordWithSpace.Length);
                    wrappedLines.Add(actualLine.ToString());
                    actualLine = new StringBuilder();
                    actualLine.Append(wordWithSpace);
                    actualWidth = 0;
                    actualWidth += formattedWord.Width;
                }
            }
            if (actualLine.Length > 0)
                wrappedLines.Add(actualLine.ToString());
            return wrappedLines;
        }
