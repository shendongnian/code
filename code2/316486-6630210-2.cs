    <%@ Page Language="C#" AutoEventWireup="true" Inherits="Access.Login" %>
    
    <script runat="server">
    	protected void Page_Load(object sender, EventArgs e) {
    		if (!Page.IsPostBack) {
    			Controls.Add(whatever);
    		}
    	}
    </script>
    <!-- Try this if the above does not work -->
    <script runat="server">
        	new protected void Page_Load(object sender, EventArgs e) {
            base.Page_Load(sender, e);
        		if (!Page.IsPostBack) {
        			Controls.Add(whatever);
        		}
        	}
    </script>
