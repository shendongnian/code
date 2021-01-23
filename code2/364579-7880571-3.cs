    class Robot : System.Object
    {
        public virtual void Speak()
        {
           MessageBox.Show("Robot says hi");
        }
    }
    class Cyborg : Robot
    {
      public override void Speak()
      {
          base.Speak(); 
          MessageBox.Show("hi");
      }
    }
