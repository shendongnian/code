    <asp:repeater runat="server" id="rpt">
    
    </ItemTemplate>
    <asp:LinkButton runat="serevr" id="btnLink">"+<%#Eval("ticketNo")%>  <%#Eval("subject")%>  <%#Eval("qu")%>
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
