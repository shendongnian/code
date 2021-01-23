       [HttpPost]
        public ActionResult ViewMyProducts(ViewMyProductsViewModel viewModel)
        {
            if(viewModel.MyTextArea == "something" && (IEnumerable<foo>)myModel).Count()==5))         {
              var model = repo.Get(myModel.First().Id);
              // do something with the model
            }
            return View(viewModel);
        }
    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MyProject.MyDB.MyProducts>>" %>
    <%@ Import Namespace="MyProject.MyDB" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        <% using (Html.BeginForm())
           {%>
        <table>        
            <%
                foreach (var item in Model)
                {%>
            <tr>
                <td>
                    <input type="hidden" name="viewModel.Id" value="<%:item.id%>" />
                    <%:item.name%>
                </td>
                <td>
                    <%:String.Format("{0:g}", item.date)%>
                </td>
            </tr>
            <% } %>
        </table>
        <div>
            <%:Html.TextArea("MyTextArea")%>
        </div>    
        <p>
            <input type="submit" value="Send" />
        </p>
        <% } %>
    </asp:Content>
