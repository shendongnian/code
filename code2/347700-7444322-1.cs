    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.UI;
    using MvcApplication5.Models.ViewModels;
    using Telerik.Web.UI;
    
    namespace MvcApplication5.Views.Shared
    {
        public class RadGridExample : ViewUserControl
        {
            protected void Page_Init()
            {
                RadGrid grid = this.Controls[0].FindControl("RadGrid1") as RadGrid;
    
                grid.NeedDataSource += new GridNeedDataSourceEventHandler(grid_NeedDataSource);
    
                grid.DataBind();
    
                string viewState = Request.Form["__VIEWSTATE"];
    
                if (!string.IsNullOrEmpty(viewState))
                {
                    LosFormatter formatter = new LosFormatter();
    
                    object savedStateObject = formatter.Deserialize(viewState);
    
                    MethodInfo method = grid.GetType().GetMethod("LoadViewState", BindingFlags.NonPublic | BindingFlags.Instance);
    
                    // TODO: Find a less brittle/more elegant way to isolate the appropiate viewstate object for this control
                    // In the case of Telerik's RadGrid, the key wasy find the tree that had an array of 13 objects
                    method.Invoke(grid, new object[] { (((((((((savedStateObject as Pair).First as Pair).Second as Pair).Second as System.Collections.ArrayList)[1] as Pair).Second as System.Collections.ArrayList)[1] as Pair).Second as System.Collections.ArrayList)[1] as Pair).First });
                }
    
                string eventArgument = Request.Form["__EVENTARGUMENT"];
    
                if (!string.IsNullOrEmpty(eventArgument))
                {
                    grid.RaisePostBackEvent(eventArgument);
                }
            }
    
            void grid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
            {
                (sender as RadGrid).DataSource = this.Model as HomeIndexViewModel;
            }
        }
    }
