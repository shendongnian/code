    /// <summary>
        /// Determines the pagenumber of a range.
        /// </summary>
        /// <param name="range">The range to be located.</param>
        /// <returns></returns>
        private static int GetPageNumberOfRange(Word.Range range)
        {
            return (int)range.get_Information(Word.WdInformation.wdActiveEndPageNumber);
        }
