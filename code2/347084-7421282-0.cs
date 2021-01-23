    public inteface IPlayerBase 
    {
       void Render();
    }
    public class FieldPlayer : IPlayerBase
    {
       public void Render()
       {
          MessageBox.Show("FieldPlayer.Render");
       }
    }
    public class GoalKeeper : IPlayerBase
    {
       public void Render()
       {
          MessageBox.Show("GoalKeeper.Render");
       }
    }
