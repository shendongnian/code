    <%@ Page Language="C#" %>
    <%
        void Page_Load(Object sender, EventArgs e)
        {
            try
            {
                string message = "Text";
                Response.Write(method1(message));
            }
            catch
            {
                Response.Write("Err");
            }
        }
    
        string method1(string source)
        {
            return source;
        }
    %>
