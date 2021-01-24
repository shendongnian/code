        using System;
        using System.Data;
        using System.Configuration;
        using System.Collections;
        using System.Web;
        using System.Web.Security;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Web.UI.WebControls.WebParts;
        using System.Web.UI.HtmlControls;
        using System.IO;
        using System.Data.SqlClient;
        using System.Net;
        using Ionic.Zip;
    
    namespace test.admin
    {
        public partial class downloadImages : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void submit_Click(object sender, EventArgs e)
            {
                // delete existing images in the folder
                var di = new DirectoryInfo(Server.MapPath("~/images"));
                foreach (var file in di.EnumerateFiles())
                {
                    file.Delete();
                }
    
                // create images and store them in the images folder
                DataTable dt = GetData("SELECT * FROM mytable");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    byte[] bytes = (byte[])dt.Rows[i]["photo"];
                    File.WriteAllBytes(Server.MapPath("~/images/" + dt.Rows[i]["eID"] + ".jpg"), bytes);
                }
    
                // use this to download the zip file
                using (ZipFile zip = new ZipFile())
                {
                    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    zip.AddDirectory(Server.MapPath("~/images/"))
    
                    Response.Clear();
                    Response.BufferOutput = false;
                    string zipName = String.Format("sasImages.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                    Response.ContentType = "application/zip";
                    Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    zip.Save(Response.OutputStream);
                    Response.End();
                }
    
    
            }
    
            protected void delete_Click(object sender, EventArgs e)
            {
    
                // delete existing images in the folder
                var di = new DirectoryInfo(Server.MapPath("~/images"));
                foreach (var file in di.EnumerateFiles())
                {
                    file.Delete();
                }
    
                string script = "alert('All files in the folder deleted successfully');";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
            }
    
            private DataTable GetData(string query)
            {
                DataTable dt = new DataTable();
                string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            sda.Fill(dt);
                        }
                    }
    
                    return dt;
                }
            }
    
        }
    }
