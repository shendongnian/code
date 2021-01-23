    public partial class BindablePage : System.Web.UI.Page
	{
		public static object DataContext { get; set; }
		public void UpdateDataContext()
		{
			if (DataContext == null)
			{
				return;
			}
			List<BindableTextBox> controls = new List<BindableTextBox>();
			_getControlList(Page.Controls, controls);
			foreach (var control in controls)
			{
				DataContext.GetType().GetProperty(((BindableTextBox)control).Path).SetValue(DataContext, ((BindableTextBox)control).Text, null);
			}
		}
		private void _getControlList(ControlCollection controlCollection, List<BindableTextBox> resultCollection)
		{
			foreach (Control control in controlCollection)
			{
				if (control is BindableTextBox)
				{
					resultCollection.Add((BindableTextBox)control);
				}
				if (control.HasControls())
				{
					_getControlList(control.Controls, resultCollection);
				}
			}
		}
	}
	public class BindableTextBox : TextBox
	{
		public string Path { get; set; }
	}
	public partial class AddEmployee : BindablePage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				DataContext = new User();
			}
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
			UpdateDataContext();
		}
	}
