	using System;
	using System.Collections.Generic;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using TestProject.UserControls;
	namespace TestProject
	{
		public partial class _Default : Page
		{
			protected void Page_Load(object sender, EventArgs e)
			{
				if (!Page.IsPostBack)
				{
					divContent.InnerHtml =
						"<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante" + 
						" dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. Fusce" +
						" nec tellus sed augue semper porta. Mauris massa. Vestibulum lacinia arcu eget nulla. Class aptent taciti sociosqu" +
						" ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur sodales ligula in libero. Sed dignissim" +
						" lacinia nunc. </p>" +
						"<p>Curabitur tortor. Pellentesque nibh. Aenean quam. In scelerisque sem at dolor. Maecenas mattis. Sed convallis" +
						" tristique sem. Proin ut ligula vel nunc egestas porttitor. Morbi lectus risus, iaculis vel, suscipit quis, luctus" +
						" non, massa. Fusce ac turpis quis ligula lacinia aliquet. Mauris ipsum. Nulla metus metus, ullamcorper vel, tincidunt" +
						" sed, euismod in, nibh. Quisque volutpat condimentum velit. Class aptent taciti sociosqu ad litora torquent per conubia" +
						" nostra, per inceptos himenaeos. </p>" +
						"<p>Nam nec ante. Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis." +
						" Nulla facilisi. Ut fringilla. Suspendisse potenti. Nunc feugiat mi a tellus consequat imperdiet. Vestibulum sapien. Proin" +
						" quam. Etiam ultrices. Suspendisse in justo eu magna luctus suscipit. Sed lectus. Integer euismod lacus luctus magna. Quisque" +
						" cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam. Vestibulum ante ipsum primis in" +
						" faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui. </p>" +
						"<p>Praesent blandit dolor. Sed non quam. In vel mi sit amet augue congue elementum. Morbi in ipsum sit amet pede facilisis" +
						" laoreet. Donec lacus nunc, viverra nec, blandit vel, egestas et, augue. Vestibulum tincidunt malesuada tellus. Ut ultrices" +
						" ultrices enim. Curabitur sit amet mauris. Morbi in dui quis est pulvinar ullamcorper. Nulla facilisi. Integer lacinia sollicitudin" +
						" massa. Cras metus. </p>" +
						"<p>Sed aliquet risus a tortor. Integer id quam. Morbi mi. Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet," +
						" augue. Proin sodales libero eget ante. Nulla quam. Aenean laoreet. Vestibulum nisi lectus, commodo ac, facilisis ac, ultricies eu," +
						" pede. Ut orci risus, accumsan porttitor, cursus quis, aliquet eget, justo. Sed pretium blandit orci. Ut eu diam at pede suscipit" +
						" sodales. Aenean lectus elit, fermentum non, convallis id, sagittis at, neque. Nullam mauris orci, aliquet et, iaculis et, viverra" +
						" vitae, ligula. </p>";
					//Clear session on first load
					Session["controls"] = null;
				}
				if (Session["controls"] != null)
				{
					RenderControls(Session["controls"] as List<Control>);
					var postbackInit = GetPostBackControl(this);
					LbClick(postbackInit, null);
				}
			}
			//Get Control that caused postback
			public static Control GetPostBackControl(Page page)
			{
				Control control = null;
				string ctrlname = page.Request.Params.Get("__EVENTTARGET");
				if (!string.IsNullOrEmpty(ctrlname))
				{
					control = page.FindControl(ctrlname);
				}
				else
				{
					foreach (string ctl in page.Request.Form)
					{
						Control c = page.FindControl(ctl);
						if (c is Button)
						{
							control = c;
							break;
						}
					}
				}
				return control;
			}
			public void Partial_Postback(ucA sender)
			{
				var counter = 5;
				var controls = new List<Control>();
				sender.Key = counter;
				sender.ID = counter.ToString();
				controls.Add(sender);
				Session["controls"] = controls;
				RenderControls(controls);
				sender.LbDetails.ID = counter.ToString();
			}
			private void RenderControls(List<Control> controls)
			{
				foreach (var control in controls)
				{
					var controlReference = Page.FindControl(control.ID);
					if (controlReference == null)
					{
						divContent.Controls.Add(control);
					}
				}
				upMain.Update();
			}
			private void LbClick(object sender, EventArgs e)
			{
				divContent.InnerHtml = string.Empty;
				divContent.InnerText = string.Format("trigger works and ID = {0}", (sender as LinkButton).ID);
				upMain.Update();
			}
			public void BtnClick(object sender, EventArgs e)
			{
				var controlA = new ucA();
				controlA = (ucA)LoadControl("~/UserControls/ucA.ascx");
				divContent.Controls.Add(controlA);
			}
		}
	}
	
