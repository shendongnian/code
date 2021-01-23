    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.Web" %>
    <%@ Import Namespace="System.IO" %>
    <script runat="server">
      public void Page_Load(object sender, EventArgs e){
        HttpContext c = HttpContext.Current;
        //string data = Decode(c.Request["file"]);
        //string name = c.Request["name"];
        Response.Write(Server.MapPath("/temp/hurrdurr.txt"));
        string name = "target.docx";
        string data = "THE GIANT BASE 64 DATA";
        using(StreamWriter writer = new StreamWriter(Server.MapPath("/temp/"+name), true)){
          writer.WriteLine(Decode(data));
          writer.Close();
        }
        FileStream fs = File.Open(Server.MapPath("/temp/"+name), FileMode.Open);
        byte[] file = new byte[fs.Length];
        fs.Read(file, 0, Convert.ToInt32(fs.Length));
        fs.Close();
        Response.AddHeader("Content-disposition", "attachment; filename=" + name);
        Response.ContentType = "application/octet-stream";
        Response.BinaryWrite(file);
        Response.End();
      }
      public string Decode(string str){
        byte[] decbuff = Convert.FromBase64String(str);
        return System.Text.Encoding.UTF8.GetString(decbuff);
      }
    </script>
