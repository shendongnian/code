    select new
    {
       Duration = (string)f.Element("duration"),
       Cabin = (string)f.Element("class"),
       Price = "$" + (Int32)f.Element("price")
       ImagePath = (string)f.Element("airlineImage")
    };
    <asp:GridView runat="server" ID="GridView1">
       <Columns>
          <asp:ImageField DataImageUrlField="ImagePath" 
                          DataImageUrlFormatString="~/Content/Images/{0}" />
       </Columns>
    </asp:GridView>`enter code here`
