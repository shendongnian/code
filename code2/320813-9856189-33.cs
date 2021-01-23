        private void FormatCode(TextContentChangedEventArgs e)
        {
            if (e.Changes != null)
            {
                for (int i = 0; i < e.Changes.Count; i++)
                {
                    HandleChange(e.Changes[0].NewText);
                }
            }
        }
