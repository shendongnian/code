    class Robot : System.Object
    {
      public void Speak()
      {
        MessageBox.Show("Robot says hi");
      }
    }
     
    class Cyborg : Robot
    {
      new public void Speak()
      {
        MessageBox.Show("hi");
      }
    }
