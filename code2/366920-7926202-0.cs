    class MyMessageBox : Form {
      private MyMessageBox currentForm; // The currently active message box
      public static Show(....) { // same as MessageBox.Show
        // ...
      }
      public static Show(...) { // define additional overloads
      }
      public static CloseCurrent() {
        if (currentForm != null)
          currentForm.Close();
      }
      // ...
    }
