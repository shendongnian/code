    <%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"%>
    <script language="cs" runat="server">
    	public void Page_Load(object sender, EventArgs e)
    	{
    
    		byte[] buffer;
    		using (var memoryStream = new System.IO.MemoryStream())
    		{
    			buffer = Encoding.Default.GetBytes("Hello StackOverflow"); //Dummy data
    			memoryStream.Write(buffer, 0, buffer.Length);
    			Response.Clear();
    			Response.AddHeader("Content-Disposition", "attachment; filename=hello.txt"); //This wil force browser to silently download file. you can comment this line to see difference
    			Response.AddHeader("Content-Length", memoryStream.Length.ToString());
    			Response.ContentType = "text/plain"; //This is MIME type
    			memoryStream.WriteTo(Response.OutputStream);
    		}
    		Response.End();
    		
    	}
    </script>
