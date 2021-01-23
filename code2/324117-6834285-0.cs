     public class StateContainer
     {
         public int AsyncExecutions { get; set;}
     }
    public class ThreadForm : Form
    {
         private StateContainer _state;
     
         public ThreadForm (StateContainer state)
         {
              _state = state;
              _state.AsyncExecutions = 1;
         }
    
         private void start_Button_Click(object sender, EventArgs e)
         {
              Int.TryParse(TextBox.Text, out _state.AsyncExecutions);
         }
    }
