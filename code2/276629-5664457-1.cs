    public partial class _Default : System.Web.UI.Page
    {
        SampleConnectionClassDataContext sampleContext = new SampleConnectionClassDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCheckedGrid();
                BindNonCheckedGrid();
            }
        }
        private void BindCheckedGrid()
        {
            var checkedItems = from check in sampleContext.CheckboxSamples
                               where check.Discriminator == true
                               select check;
            grdSelected.DataSource = checkedItems;
            grdSelected.DataBind();
        }
        private void BindNonCheckedGrid()
        {
            var checkedItems = from check in sampleContext.CheckboxSamples
                               where check.Discriminator == false
                               select check;
            grdNotSelected.DataSource = checkedItems;
            grdNotSelected.DataBind();
        }
        protected void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            Label lblID = (Label)row.FindControl("lblCheckedID");
            var existingEntry = from s in sampleContext.CheckboxSamples
                                where s.ID == int.Parse(lblID.Text)
                                select s;
            existingEntry.First().Discriminator = checkbox.Checked;
            sampleContext.SubmitChanges();
            BindCheckedGrid();
            BindNonCheckedGrid();
        }
    }
