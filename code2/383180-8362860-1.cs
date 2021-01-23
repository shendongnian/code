    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace SO8362448
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                gridView.DataSource = new List<Person>
                {
                    new Person {Name = "Steve", Age = 21},
                    new Person {Name = "Cindy", Age = 34}
                };
                gridView.DataBind();
            }
    
            protected void gridView_rowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lb = e.Row.FindControl("hyperLink") as LinkButton;
                    if (lb != null)
                    {
                        HiddenField hf = e.Row.FindControl("hiddenField") as HiddenField;
                        if (hf != null)
                        {
                            hf.Value = lb.Text;
                        }
                    }
                }
            }
        }
    }
