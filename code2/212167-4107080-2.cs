    private void btnStart_Click(object sender, EventArgs e)
    {
      ThreadTest cColor = new ThreadTest();
      Thread tColor = new Thread(new ParameterizedThreadStart(cColor.ChangeColor));
      tColor.Start(this);
    }
    public class ThreadTest
    {
      public void ChangeColor(Object state)
      {
        Form1 foo = (Form1) state;
        while (true)
        {
          foo.theLabel = Color.Aqua;
          foo.theLabel = Color.Black;
          foo.theLabel = Color.DarkKhaki;
          foo.theLabel = Color.Green;
        }
      }
    } 
