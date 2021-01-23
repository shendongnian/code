	namespace myspace
	{
		public partial class EmployeePage : System.Web.UI.Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				//now you should get the correct url
				//you can generate it right here but i prefer to use a special method to
				//ensure that this url will be the same in all places of my code
				string emptyEmpIdPostbackUrl = Utils.GetEmployeePageURL("");
				//now call the main method
				Utils.CreatePostbackUrl(this, "SetFilterUrl", emptyEmpIdPostbackUrl,
					new List<WebControl> { ddlFilterCompany, ddlFilterDepartment, ddlFilterOwner, 
						ddlFilterType, ddlFilterDiscarded, ddlFilterChangeDate });
				if (!IsPostBack)
				{
					...
				}
		   }
		   
		   ...
		   
		}   
		public static class Utils
		{
			//page - your gridview page
			//name - some custom name to ensure that different postbacks will work independently from each other
			//url - the url with empty employee id
			//controls - list of webcontrols for which you want to create postback url (i've got 6 dropdownlists in my own page)
			public static void CreatePostbackUrl(Page page, string name, string url, List<WebControl> controls)
			{
				//create a hidden button with your postbackurl
				Button btn = new Button();
				btn.ID = name;
				btn.PostBackUrl = url;
				btn.Attributes.Add("style", "display: none;");
				page.Form.Controls.Add(btn);
				//register javascript that will simulate click on the hidden button
				page.ClientScript.RegisterClientScriptBlock(page.GetType(), name + "Script",
					"<script type=\"text/javascript\"> function " + name + "() {" +
					"var btn = document.getElementById('" + btn.ClientID + "'); " +
					"if (btn) btn.click();} </script>", false);
				//and link this script to each dropdownlist in the list
				foreach (WebControl ctrl in controls)
				{
					string attrName = "";
					if (ctrl is DropDownList)
						attrName = "onchange";
					if (attrName != "")
						ctrl.Attributes.Add(attrName, name + "()");
				}
			}
			
			public static string GetEmployeePageURL(string empId)
			{
				return "emp.aspx" +
					"?empid=" + empId;
			}
		}
	}
	
