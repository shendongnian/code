     Point newLoc = new Point(5, 5);  
     ...
     if (mainForm != null) {
       Button b = new Button() {
         Size     = new Size(10, 50), 
         Location = newLoc,
         Parent   = mainForm,
       }
       newLoc.Offset(0, b.Height + 5);
     }
