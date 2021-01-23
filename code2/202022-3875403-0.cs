    <%@ Page Language="C#" %>
    
    <script runat="server" language="c#">
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		Response.ContentType = "image/png";
    	
    		System.Net.WebClient wc =  new System.Net.WebClient();
    		
    		byte[] data = wc.DownloadData("http://mystatus.skype.com/smallclassic/eric-greenberg");
    		Response.OutputStream.Write(data, 0, data.Length);
    		Response.OutputStream.Flush(); 
    		Response.End();
    	}
    </script>
