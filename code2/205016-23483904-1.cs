        public static List<string> QueryToTerms(string query)
        {
            List<string> Result = new List<string>();
            // split on the quote token
            string[] QuoteTerms = query.Split('"');
            // switch to denote if the current loop is processing words or a phrase
            bool WordTerms = true;
            foreach (string Item in QuoteTerms)
            {
                if (!string.IsNullOrWhiteSpace(Item))
                    if (WordTerms)
                    {
                        // Item contains words. parse them and ignore empty entries.
                        string[] WTerms = Item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string WTerm in WTerms)
                            Result.Add(WTerm);
                    }
                    else
                        // Item is a phrase.
                        Result.Add(Item);
                // Alternate between words and phrases.
                WordTerms = !WordTerms;
            }
            return Result;
        }
