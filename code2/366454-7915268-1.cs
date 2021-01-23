    public class CheckBoxDropDownList :
        System.Web.UI.WebControls.WebControl,INamingContainer
    {
        protected override void CreateChildControls()
        {
            base.CreateChildControls ();
            DropDownList ddl=new DropDownList();
            ListItem li=new ListItem("");
            ddl.Items.Add(li);
            ddl.Width =new Unit(100);
            ddl.Attributes.Add("onmousedown", "showdiv()");
            ddl.Attributes.Add("onclick", "showdiv()");
            ddl.Attributes.Add("ondragover", "hidediv()");
            ddl.Attributes.Add("onmouseout", "hidediv()");
            CheckBoxList cbl=new CheckBoxList();
            cbl.Width=new Unit(80);
        
            ListItem li1=new ListItem("ListItem1");
            ListItem li2=new ListItem("ListItem2");
            ListItem li3=new ListItem("ListItem3");
    
            cbl.Items.Add(li1);
            cbl.Items.Add(li2);
            cbl.Items.Add(li3);
            System.Web.UI.HtmlControls.HtmlGenericControl div=new 
                System.Web.UI.HtmlControls.HtmlGenericControl("div");
            div.ID="serverdiv";
            div.Controls.Add(cbl);
            div.Style.Add("BORDER-RIGHT", "black 1px solid");
            div.Style.Add("BORDER-TOP", "black 1px solid");
            div.Style.Add("BORDER-LEFT", "black 1px solid");
            div.Style.Add("BORDER-BOTTOM", "black 1px solid");
            div.Style.Add("VISIBILITY", "hidden");
    
            this.Controls.Add(ddl);
            this.Controls.Add(div);
        }
    }
