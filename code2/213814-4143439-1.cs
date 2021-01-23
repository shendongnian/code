     private void button_Clicked(object sender, EventArgs e)
     {
         MyButton button = sender as MyButton;
         MessageBox.Show("You clicked on " + button.Text");
     }
