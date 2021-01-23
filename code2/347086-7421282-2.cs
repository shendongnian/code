    public class PlayerBase 
    {
       public virtual void Render()
       {
          MessageBox.Show("PlayerBase.Render");
       }
    }
    public class FieldPlayer : PlayerBase
    {
       public override void Render()
       {
          MessageBox.Show("FieldPlayer.Render");
       }
    }
    public class GoalKeeper : PlayerBase
    {
       public override void Render()
       {
          MessageBox.Show("GoalKeeper.Render");
       }
    }
