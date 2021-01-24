     Point newLoc = new Point(5, 5);  
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
     }
