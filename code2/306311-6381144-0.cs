        private static string JsStringFixNonPrintable(string Source)
        {
            StringBuilder builder = new StringBuilder(Source.Length); // predefine size to be the same as input
            for (int it = 0; it < Source.Length; ++it)
            {
                var ch = Source[it];
                var CharCat = char.GetUnicodeCategory(Source, it);
                if (Char.IsWhiteSpace(ch) ||
                    CharCat == System.Globalization.UnicodeCategory.LineSeparator ||
                    CharCat == System.Globalization.UnicodeCategory.SpaceSeparator) { builder.Append(' '); continue; }
                if (Char.IsControl(ch) && ch != 10 && ch != 13) continue;
                builder.Append(ch);
            }
            return builder.ToString();
        }
