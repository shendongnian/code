    public IEnumerable<MyWord> Words { get; private set; }
    private void ShowMostPopularWords(int numberOfWords)
    {
        SortMyWordsDescending();
        listBox1.Items.Clear();
        for (int i = 0; i < numberOfWords; i++ )
        {
            listBox1.Items.Add(this.Words.ElementAt(i).Word + "|" + this.Words.ElementAt(i).Frequency);
        }
    }
