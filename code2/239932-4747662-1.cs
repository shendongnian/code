    public partial class _Default : System.Web.UI.Page
    {
        public void Test_Click(object sender, EventArgs args) 
        { 
            ResultPanel.Controls.Add(new Label() { Text = "Test Click Executed" }); 
        }
        public void Test_Click2(object sender, EventArgs args) 
        { 
            ResultPanel.Controls.Add(new Label() { Text = "Test Click 2 Executed" }); 
        }
        public void Test_Click3(object sender, EventArgs args) 
        { 
            ResultPanel.Controls.Add(new Label() { Text = "Test Click 3 Executed" }); 
        }
        public void Test_Click4(object sender, EventArgs args) 
        { 
            ResultPanel.Controls.Add(new Label() { Text = "Test Click 4 Executed" }); 
        }
    }
