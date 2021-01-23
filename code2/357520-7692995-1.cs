    <asp:TextBox id="tst" runat="server" Something="TestValue"></asp:TextBox> 
     public static string GetSomething(this WebControl value)
    {
       return value.Attributes["Something"].ToString();
    }
