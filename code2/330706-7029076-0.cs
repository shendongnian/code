    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Reflection;
    namespace WebApplication2
    {
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, System.EventArgs e)
        {
            string layout = "";
            if (Request.QueryString["layout"] != null)
            {
                layout = Request.QueryString["layout"] as string;
            }
            else
            {
                layout = "default";
            }
            //if (!Page.IsPostBack) {
            GlobalMethods.InitControlList();
            LoadControls(layout);
            //}
        }
        private void AddControlsFromList()
        {
            sitemanagercontrolsdiv.Controls.Clear();
            try
            {
                if (GlobalMethods.divlayoutgencontrols != null)
                {
                    foreach (Control c in GlobalMethods.divlayoutgencontrols)
                    {
                        sitemanagercontrolsdiv.Controls.Add(c);
                    }
                }
            }
            catch (Exception eee)
            {
                string a = eee.Message;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AddControlsFromList();
        }
        //The control collection cannot be modified during 
        //DataBind, 
        //Init, 
        //Load, 
        //PreRender or 
        //Unload phases.
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //AddControlsFromList();
        }
        private void LoadControls(string layout)
        {
            Control c = LoadControl("~/TestRaiseEvent.ascx");
            Type controlType = c.GetType();
            BindingFlags myBindingFlags = BindingFlags.Instance | BindingFlags.Public;
            EventInfo[] myEvents = controlType.GetEvents(myBindingFlags);
            for (int j = 0; j < myEvents.Count(); j++)
            {
                string eventName = myEvents.ElementAt(j).Name;
                if (eventName == "ButtonClickEvent")
                {
                    MethodInfo handler = typeof(_Default).GetMethod("SomeHandler");
                    Delegate del = Delegate.CreateDelegate(myEvents.ElementAt(j).EventHandlerType, this, handler);
                    myEvents.ElementAt(j).AddEventHandler(c, del);
                }
            }
            c.Visible = true;
            //string tempGUID = Guid.NewGuid().ToString();
            //c.ID = "TestRaiseEvent" + tempGUID + "1";
            c.ID = "TestRaiseEvent1";
            GlobalMethods.divlayoutgencontrols.Add(c);
        }
        public void SomeHandler(string message)
        {
            // do something
        }
    }
}
