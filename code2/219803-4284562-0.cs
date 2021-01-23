        private bool TryParseContent(string text, out DateTime date, out int index)
        {
            date = DateTime.MinValue;
            index = -1;
            if (text.Length < 17)
                return false;
            string idPart = text.Substring(0, 4);
            if (idPart != "ID_P" && idPart != "ID P")
                return false;
            string datePart = text.Substring(4, 8);
            if (!DateTime.TryParseExact(datePart, "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None, out date))
                return false;
            // TODO: do additional validation of the date
            string indexPart = text.Substring(13, 4);
            if (!int.TryParse(indexPart, out index))
                return false;
            return true;
        }
