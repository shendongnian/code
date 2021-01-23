    public void ShowWord()
    {
      _word = new Word.Application();
      _word.Visible = true;
      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      while (!_word.Visible && sw.ElapsedMilliseconds < 10000)
      { /* Just Wait!! (at most 10s) */}
      _word.Activate();
    }
