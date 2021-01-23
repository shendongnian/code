    <asp:PlaceHolder ID="phDynamicTextBox" runat="server" />
    
    int inputFromPreviousPost = 4;
    for(int i = 1; i <= inputFromPreviousPost; i++)
    {
        TextBox t = new TextBox();
        t.ID = "name" + i.ToString();
    }
    
    //on button click retrieve controls inside placeholder control
    protected void Button_Click(object sender, EventArgs e)
    {
       foreach(Control c in phDynamicTextBox.Controls)
       {
           try
           {
               TextBox t = (TextBox)c;
               
               // gets textbox ID property
               Response.Write(t.ID);
           }
           catch
           {
           }
       }
    }
