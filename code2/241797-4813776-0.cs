    private void btnSpelling_Click(object sender, RoutedEventArgs e)
        {
            SpellChecklistBox.Items.Clear();
            string[] articleWordsArray = txtArticle.Text.Split(' ');
            foreach (string word in articleWordsArray)
            {
                articleWords.Enqueue(word);
                
            }
            CorrectWord();
            
        }
    private void SpellChecklistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SpellCheckerPopup.IsOpen = false;
        }
    private void SpellCheckerPopup_Closed(object sender, EventArgs e)
        {
            CorrectWord();
            SpellChecklistBox.Items.Clear();
        }
    Queue<string> articleWords = new Queue<string>();
        private void CorrectWord()
        {
            if (articleWords.Count() > 0)
            {
                string checkedWord = articleWords.Dequeue();
                bool success = _spellChecker.CheckWord(checkedWord);
                List<string> suggest;
                if (!success)
                {
                    suggest = _spellChecker.GetSuggestions(checkedWord);
                    
                    foreach (string s in suggest)
                    {
                        SpellChecklistBox.Items.Add(new ListBoxItem() { Content = s });
                    }
                    SpellCheckerPopup.IsOpen = true;
                    SpellChecklistBox.Items.Add(new ListBoxItem() { Content = "          ----------------------" });
                    SpellChecklistBox.Items.Add(new ListBoxItem() { Content = "Ignore" });
                    SpellCheckerPopup.IsOpen = true;
                }
            }
        }
