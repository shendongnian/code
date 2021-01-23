    void flpChoices_MouseWheel(object sender, MouseEventArgs e)
    {
      Control c=flpChoices.GetChildAtPoint(new Point(10, 10), GetChildAtPointSkip.None);
      if (c == null) flpChoices.PerformLayout();
    
    }
