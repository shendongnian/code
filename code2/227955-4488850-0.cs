    private void txtTest_MouseMove(object sender, MouseEventArgs e)
    {
       string str = "Character{0} is at Position{1}";
       Point pt = txtTest.PointToClient(Control.MousePosition);
       MessageBox.Show(
          string.Format(str
          , txtTest.GetCharFromPosition(pt).ToString()
          , txtTest.GetCharIndexFromPosition(pt).ToString())
       );
    }
