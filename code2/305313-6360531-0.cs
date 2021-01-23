    public partial class GuessNumber : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblResult.Text += "Written in by Page_Load <br />";
        }
        protected void LoveMyButtons_click(object sender, EventArgs e) {
            string response = txtGuess.Text;
            lblResult.Text += string.Format("LoveMybuttons " + response + " <br />");
        }
        protected void Page_PreInit(object sender, EventArgs e) {
            CreateButtons();
        }
        List<Button> btns;
        public void CreateButtons() {
            btns = new List<Button>();
            for (int i = 0; i < 6; i++) {
                Button butt = new Button();
                butt.Text = "Click me";
                butt.Click += LoveMyButtons_click;
                btns.Add(butt);
            }
            AddMyButtonsToAPlaceHolder();
        }
        public void AddMyButtonsToAPlaceHolder() {
            foreach (var item in btns) {
                plhButtonStore.Controls.Add(item);
            }
        }
    }
    <body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtGuess" runat="server" />
        <asp:Button ID="btnPeanut" runat="server" Text="Guess" />
        <br /><br />
        <asp:Label ID="lblNumberOfGuesses" runat="server" />
        <br />
        <asp:Label ID="lblResult" runat="server" />
        <br />
        <asp:PlaceHolder ID="plhButtonStore" runat="server" />
    </div>
    </form>
    </body>
