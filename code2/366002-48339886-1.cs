    <form id="form1" runat="server">
        <div style="font-size: 30px; padding: 25px; text-align: center;">
            Get Current Date And Time Of All TimeZones
        </div>
        <hr />
        <div style="font-size: 18px; padding: 25px; text-align: center;">
            <div class="clsLeft">
                Select TimeZone :-
            </div>
            <div class="clsRight">
                <asp:DropDownList ID="ddlTimeZone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTimeZone_SelectedIndexChanged"
                    Font-Size="18px">
                </asp:DropDownList>
            </div>
            <div class="clearspace">
            </div>
            <div class="clsLeft">
                Selected TimeZone :-
            </div>
            <div class="clsRight">
                <asp:Label ID="lblTimeZone" runat="server" Text="" />
            </div>
            <div class="clearspace">
            </div>
            <div class="clsLeft">
                Current Date And Time :-
            </div>
            <div class="clsRight">
                <asp:Label ID="lblCurrentDateTime" runat="server" Text="" />
            </div>
        </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        </form>
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTimeZone();
                GetSelectedTimeZone();
            }
        }
 
        protected void ddlTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedTimeZone();
        }
 
        /// <summary>
        /// Get all timezone from local system and bind it in dropdownlist
        /// </summary>
        private void BindTimeZone()
        {
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            {
                ddlTimeZone.Items.Add(new ListItem(z.DisplayName, z.Id));
            }
        }
 
        /// <summary>
        /// Get selected timezone and current date & time
        /// </summary>
        private void GetSelectedTimeZone()
        {
            DateTimeOffset newTime = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(ddlTimeZone.SelectedValue));
            //DateTimeOffset newTime2 = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(ddlTimeZone.SelectedValue));
            lblTimeZone.Text = ddlTimeZone.SelectedItem.Text;
            lblCurrentDateTime.Text = newTime.ToString();
            string str;
            str = lblCurrentDateTime.Text;
            string s=str.Substring(0, 10);
            DateTime dt = new DateTime();
            dt = Convert.ToDateTime(s);
           // Response.Write(dt.ToString());
            Response.Write(ddlTimeZone.SelectedValue);
        }
