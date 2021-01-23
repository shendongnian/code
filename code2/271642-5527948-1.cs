    private void createControls()
    {
        int count = this.NumberOfControls;
        for(int i = 0; i < count; i++)
        {
            TextBox tx = new TextBox();
            tx.ID = "ControlID_" + i.ToString();
            //Add the Controls to the container of your choice
            MyContainer.Controls.Add(tx);
        }
    } 
