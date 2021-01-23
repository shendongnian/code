    public partial class Messages : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialise the dropdown list values
                var types = Enum.GetValues(typeof(MessageType));
                types.Remove(MessageType.None);
                foreach (var t in types)
                {
                    ddlType.Items.Add(new ListItem(t.ToString()));
                }
                
                // Default message filter and sort
                Type = MessageType.All;
                lvMessages.Sort("Timestamp", SortDirection.Descending);
            }
        }
        private MessageType _type;
        public MessageType Type
        {
            get { return _type; }
            set
            {
                if (!_type.Equals(value))
                {
                    ddlType.SelectedValue = value.ToString();
                    _type = value;
                }
            }
        }
        private static readonly IDictionary<SortDirection, string> SortIndicators =
            new Dictionary<SortDirection, string>
                {
                    {SortDirection.Ascending, "\u25b4"}, // upwards triangle
                    {SortDirection.Descending, "\u25be"} // downwards triangle
                };
        /// This is where you can programmatically add / change the values of
        /// parameters that will get passed to MessagesDataSource.Select()
        protected void dsMessages_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            // Add "filter" parameters that have to be determined programmatically.
            e.InputParameters["username"] = GetUsernameLoggedIn();
            e.InputParameters["type"] = Type;
        }
        /// When the message type changes, go back to the first page
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type = (MessageType) ddlType.SelectedValue);
            var pager = (DataPager)lvMessages.FindControl("dpMessages");
            if (pager == null)
            {
                ((IPageableItemContainer)lvMessages).SetPageProperties(0, 10, true);
            }
            else
            {
                pager.SetPageProperties(0, pager.PageSize, true);
            }
        }
        /// Reload the value from the dropdown list.
        protected void ddlType_Load(object sender, EventArgs e)
        {
            Type = (MessageType) ddlType.SelectedValue;
        }
        protected void UpdateSortIndicator(object sender, EventArgs e)
        {
            var indicator = (Literal) sender;
            if (indicator.ID.EndsWith("__"+ lvMessages.SortExpression))
            {
                indicator.Text = SortIndicators[lvMessages.SortDirection];
            } 
            else
            {
                indicator.Text = "";
            }
        }
    }
