        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowElement"></param>
        /// <param name="cellIndex">0-based cell index.</param>
        /// <returns></returns>
        public string GetCellData(XmlElement rowElement, int cellIndex)
        {
            XmlNodeList cellElements = rowElement.SelectNodes("ss:Cell", xmlnsManager);
            if (cellElements != null)
            {
                int elementIndex = 0;
                foreach (XmlElement cellElement in cellElements)
                {
                    // Special case: cells can be skipped. If so, there is a ss:Index attribute that contains the 1-based index of the cell.
                    if (cellElement.HasAttribute("ss:Index"))
                    {
                        elementIndex = Convert.ToInt32(cellElement.GetAttribute("ss:Index")) - 1;
                    }
                    // If cell has been skipped.
                    if (cellIndex < elementIndex)
                        return null;
                    if (cellIndex == elementIndex)
                        return cellElement.InnerText.Trim();
                    elementIndex++;
                }
            }
            return null;
        }
