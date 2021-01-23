    private Button Button1 {
        get { return (Button)this.FindControl("textUpdatedButton"); }
    }
    //This was created from the Designer and is class-scoped
    private void btn_Frame_TSK1_Click(object sender, EventArgs e)
    {
        if(this.Button1 != null){
            this.Button1.Text = "Text changed!";
        }
    }
