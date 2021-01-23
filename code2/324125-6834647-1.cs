    private void Grid_Click(object sender, RoutedEventArgs e)
    {
        if (index == Words.Count() - 1) return;
        if ((((e.Source as Button).Content as Viewbox).Child as Label).Content.ToString() == Words[index].LetterCorrect)
        {
            (letters.Children[Words[index].index] as TextBlock).Text = Words[index].LetterCorrect;
    
            Scheduler.ThreadPool.Schedule(schedule =>
            {
               letters.Children.Clear();
               LoadWord(++index);
               this.DataContext = Words[index];
        
            }, TimeSpan.FromSeconds(1));
        }
    }
