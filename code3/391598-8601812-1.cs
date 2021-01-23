    you can use GridView or Repeater and in Iteme Template you can put button. and bind perticular grid or repeater.
    
        <asp:repeater runat="server" id="rpt">
        
        </ItemTemplate>
        <asp:LinkButton runat="serevr" ID="lbtnLInkButton"  CommandArgument='<%#Eval("ID") %>' CommandName="Edit" OnClick="lbtnLInkButton_Click">"+<%#Eval("ticketNo")%>  <%#Eval("subject")%>  <%#Eval("qu")%>
        </ItemTemplate>
        </asp:repeater>
        
        
        Bind This Repeater to Datatable or make Dummy DataTable and bind it.
        
        
                DataTable dt = new DataTable();
                dt.Columns.Add("ticketNo");
                dt.Columns.Add("Subject");
                dt.Columns.Add("qu");
        
        for (int i = 0; i < list.Count; i++)
            {
        
          dt.Rows.Add(new object[] { "Ticket Number Value", "Subject Value", "qu Value"});
        
        }
        
        rpt.DataSource = dt;
        rpt.DAtabind();
    
    You can get button event like this 
    
        protected void lbtnLInkButton_Click(object sender, EventArgs e)
            {
                int i = Convert.ToInt32(((LinkButton)sender).CommandArgument);
        
            }
    
    
    
    ***Note : I have writtern the code extempore and not rested it on Visual Studio so there  May be Some Spelling Mistakes.**
