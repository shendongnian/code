        /// <summary>
        /// Given a line of text, swap position of class and id tags.
        /// Id should always precede class tag
        /// 
        /// </summary>
        /// <param name="input"><td class="m92_t_col5" id="preis_0">xx</td></param>
        /// <returns><td id="preis_0" class="m92_t_col5">xx</td></returns>
        public static string SwapClassAndId(string input)
        {
            string output = string.Empty;
            int classOrdinal = 0;
            int classOridnalEndQuotes = 0;
            string classText = string.Empty;
            int idOrdinal = 0;
            int idOrdinalEndQuotes = 0;
            string idText = string.Empty;
            classOrdinal = input.IndexOf("class=");
            classOridnalEndQuotes = input.IndexOf("\"", classOrdinal + 7) + 1;
            idOrdinal = input.IndexOf("id=");
            idOrdinalEndQuotes = input.IndexOf("\"", idOrdinal + 4) + 1;
            if (idOrdinal < classOrdinal)
            {
                return input;
            }
            classText = input.Substring(classOrdinal, classOridnalEndQuotes - classOrdinal);
            idText = input.Substring(idOrdinal, idOrdinalEndQuotes - idOrdinal);
            output = input.Replace(classText, "~~|~").Replace(idText, classText).Replace("~~|~", idText);
            return output;
        }
