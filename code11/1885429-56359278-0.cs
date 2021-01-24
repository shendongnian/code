`
private void PbFactuur_Click(object sender, EventArgs e)
 {
     if (NewPage) //Same use as the NewPage bool from above
     {
         MouseY = MousePosition.Y - 76; //Saving mouse position
         Form1.MainController.DrawRect(MouseY, PbFactuur.Image); //Function call
         NewPage = false; //Set new page to false to prevent overdrawing
         MessageBox.Show("I have executed the function"); //Debug info
         Refresh();//<----- This line fixed the problem
     }
 }
`
