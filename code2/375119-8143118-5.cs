    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    
    namespace FileDownloads
    {
        public partial class _default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (IsPostBack) return;
                
                var directory = Server.MapPath("~/downloads/");
                var filePaths = Directory.GetFiles(directory);
    
                downloadsGridView.DataSource = filePaths.Select(x => new DLFile
                {
                    Name = x.Split('\\').Last()
                });
                downloadsGridView.DataBind();
            }
    
            public class DLFile
            {
                public string Name { get; set; }
            }
        }
    }
