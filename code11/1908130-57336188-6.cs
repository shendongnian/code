    class FixSpellingErrorEventArgs : EventArgs
    {
      public System.Windows.Controls.TextBox TextBox { get; set; }
      public int WordStartIndex { get; set; }
      public int WordEndIndex { get; set; }
      public string Suggestion { get; set; }
    }
