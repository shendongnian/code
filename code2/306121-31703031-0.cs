    /// <summary>
    /// helpful class to build csv document
    /// </summary>
    public class CsvBuilder
    {
        /// <summary>
        /// create the csv builder
        /// </summary>
        public CsvBuilder(char csvSeparator)
        {
            m_csvSeparator = csvSeparator;
        }
        
        /// <summary>
        /// append a cell
        /// </summary>
        public void appendCell(string strCellValue)
        {
            if (m_nCurrentColumnIndex > 0) m_strBuilder.Append(m_csvSeparator);
            bool mustQuote = (strCellValue.Contains(m_csvSeparator)
                            || strCellValue.Contains('\"') 
                            || strCellValue.Contains('\r') 
                            || strCellValue.Contains('\n'));
            if (mustQuote)
            {
                m_strBuilder.Append('\"');
                foreach (char nextChar in strCellValue)
                {
                    m_strBuilder.Append(nextChar);
                    if (nextChar == '"') m_strBuilder.Append('\"');
                }
                m_strBuilder.Append('\"');
            }
            else
            {
                m_strBuilder.Append(strCellValue);
            }
            m_nCurrentColumnIndex++;
        }
        /// <summary>
        /// end of line, new line
        /// </summary>
        public void appendNewLine()
        {
            m_strBuilder.Append(Environment.NewLine);
            m_nCurrentColumnIndex = 0;
        }
        
        /// <summary>
        /// Create the CSV file
        /// </summary>
        /// <param name="path"></param>
        public void save(string path )
        {
            File.WriteAllText(path, ToString());
        }
        public override string ToString()
        {
            return m_strBuilder.ToString();
        }
        private StringBuilder m_strBuilder = new StringBuilder();
        private char m_csvSeparator;
        private int m_nCurrentColumnIndex = 0;
    }
