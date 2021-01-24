    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <asp:GridView ID="myGridView" ClientIDMode="Static" runat="server" AutoGenerateColumns="true"></asp:GridView>
        <asp:Button ID="myButton" runat="server" Text="---" ClientIDMode="Static" />
        <script>
            // Add event onclick on rows
            document.querySelectorAll("#myGridView tbody tr").forEach(a => a.addEventListener("click", _ => {
                document.querySelector("#myButton").value = a.children[1].innerText;
            }));
        </script>
    </asp:Content>
