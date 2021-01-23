    class MultyPagePanel : Panel
    {
      private int _currentPageIndex;
      public int CurrentPageIndex
      {
        get { return _currentPageIndex; }
        set
        {
          if (value >= 0 && value < (Controls.Count - 1))
          {
            Controls[value].BringToFront();
            _currentPageIndex = value;
          }
        }
      }
      public void AddPage(Control page)
      {
        Controls.Add(page);
        page.Dock = DockStyle.Fill;
      }
    }
