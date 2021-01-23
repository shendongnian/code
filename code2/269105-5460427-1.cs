    class UserControl1{
      public void HandleButtonClick(object sender, EventArgs e){
        ((MasterViewModel) DataContext).DoUserControlAction1();
      }
    }
