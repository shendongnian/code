    //This was created from the Designer and is class-scoped
    private void btn_Frame_TSK1_Click(object sender, EventArgs e)
    {
        Control control = this.FindControl("textUpdatedButton");
        if(control != null && control is Button){
            Button button1 = (Button)control;
            button1.Text = "Text changed!";
        }
    }
