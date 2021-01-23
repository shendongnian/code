    //Assume you have on your .aspx page:
    <asp:Panel ID="Panel_Controls" runat="server"></asp:Panel>
   
    private void button1_Click(object sender, EventArgs e)
        {
            List<Button> buttons = new List<Button>();
           
            for (int i = 0; i < buttons.Capacity; i++)
            {
                Panel_Controls.Controls.Add(buttons[i]);   
            }
        }
