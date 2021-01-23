    public abstract class PlayerBase 
    {
       public abstract void Render();
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
