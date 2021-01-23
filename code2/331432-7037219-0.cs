    using(ProgressBar pBar = new ProgressBar(obj))
    {
       if(_FileRead!=false)
       {
           pBar.Text = langSupport.GetMessages("123", cultureName);
           pBar.ShowDialog();
       }
    }
