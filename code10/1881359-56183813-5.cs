    public partial class MyChildForm : Form {
      // It seems it should be a field to store the next button position
      private Point newLoc = new Point(5, 5);  
      private Button addButtonToMainForm() {
        //TODO: Put the right type instead of MyMainForm
        MyMainForm mainForm = Application
         .OpenForms
         .OfType<MyMainForm>()
         .LastOrDefault();    
        // If Main Form has been found, let's add a button on it
        if (mainForm != null) {
          Button b = new Button() {
            Size     = new Size(10, 50), 
            Location = newLoc,
            Parent   = mainForm, // Place the button on mainForm
          }
          newLoc.Offset(0, b.Height + 5);
          return b;
        }
 
        return null;
      }
      private void myListView_ItemSelectionChanged(object sender,
                                                   ListViewItemSelectionChangedEventArgs e) {
        // If item selected (not unselected) 
        if (e.Item.Selected) {
          //TODO: Some other conditions which on the item that has been selected 
          // Button on the Main Form, null if it hasn;t been created
          Button createdButton = addButtonToMainForm();
        }
      }
      ...
