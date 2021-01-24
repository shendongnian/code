        private List<Run> GetRunItem(KeyValuePair<string, string> keyValue, bool addComma)
        {
            var inlines = new List<Run>();
            if (keyValue.Key.Equals("string", StringComparison.InvariantCultureIgnoreCase))
            {
                inlines.Add(new Run
                {
                    Text = $"[{keyValue.Key}:{keyValue.Value}]{(addComma ? "," : "")}"
                });
            }
            else
            {
                inlines.Add(new Run
                {
                    Text = $"[{keyValue.Key}:"
                });
                inlines.Add(new Run
                {
                    Text = $"{keyValue.Value}",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold
                });
                inlines.Add(new Run
                {
                    Text = $"]{(addComma ? "," : "")}"
                });
            }
            return inlines;
        }
