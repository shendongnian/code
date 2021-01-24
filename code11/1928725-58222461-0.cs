    static public void SetSizeToScreen(this Form form)
    {
      int left = Screen.PrimaryScreen.Bounds.Left;
      int top = Screen.PrimaryScreen.Bounds.Top;
      int width = Screen.PrimaryScreen.Bounds.Width;
      int height = Screen.PrimaryScreen.Bounds.Height;
      form.Location = new Point(left, top);
      form.Size = new Size(width, height);
    }
    static public void SetSizeToDesktop(this Form form)
    {
      int left = SystemInformation.WorkingArea.Left;
      int top = SystemInformation.WorkingArea.Top;
      int width = SystemInformation.WorkingArea.Width;
      int height = SystemInformation.WorkingArea.Height;
      form.Location = new Point(left, top);
      form.Size = new Size(width, height);
    }
