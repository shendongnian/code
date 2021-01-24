        private void Form1_Load(object sender, EventArgs e)
        {
            // Create User Control
            var UserCtrl = new UserControl1();
        
            // Register Event
            UserCtrl.OnCreateArrow += UserCtrl_OnCreateArrow;
            //Add Control to Form
            this.Controls.Add(UserCtrl);
        }
        // You get the Arrow object for use here
        private void UserCtrl_OnCreateArrow(Arrow arrow)
        {
            arrow.Draw();
        }
