    ValueHolder vh;
    public ChildClass (ValueHolder vhIncoming)
    {
      vh = vhIncoming;
    }
    
    private void answerBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        vh.intValue1 = 1234;
      }
    }
