    public class Form1 : Form
    {
         ... other stuff....
         protected void cmdOpenSelection_Click(object sender, EventArgs e)
         {
             using(Form2 frm = new Form2())
             {
                 // Subscribe the event giving it a method inside this class
                 // that doesn't return anything and receives a string
                 // as required by the delegate type of the event
                 frm.ItemSelected += handleItemSelection;
                 frm.ShowDialog(); // frm.Show();
             }
         }
         private void handlerItemSelection(string itemName)
         {
             // This method is a custom Event handler and inside Form1 
             // will be called by Form2 through the Invoke on the event variable 
         }
    }
