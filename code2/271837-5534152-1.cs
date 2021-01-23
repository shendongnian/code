     WrapPanel wp = new WrapPanel();
     List<Canvas> cvList = new List<Canvas>();
     List<TextBox> tbList = new List<TextBox>();
  
     public void Init()
    {
        int myInt = 500;
        // in a function (e.g. a Button_Click event) to generate the multiple Canvas in a WrapPanel
        for (int i = 0; i < myInt; i++)
        {
            Canvas cv = new Canvas();
            TextBox tb = new TextBox();
            cv.Children.Add(tb);
            wp.Children.Add(cv);
            cvList.Add(cv);
            tbList.Add(tb);
        }
    }
    public void AddCanvas()
    {
        Canvas cv = new Canvas();
        TextBox tb = new TextBox();
        cv.Children.Add(tb);
        wp.Children.Add(cv);
        cvList.Add(cv);
        tbList.Add(tb);
    }
    public void RemoveCanvas()
    {
            wp.Children.RemoveAt(wp.Children.Count-1);
            cvList.RemoveAt(cvList.Count - 1);
            tbList.RemoveAt(cvList.Count - 1);
    }
