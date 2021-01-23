    <%@ Control 
        Language="C#"
        Inherits="System.Web.Mvc.ViewUserControl<AppName.Models.MyViewModel>" %>
    <%= Html.HiddenFor(x => x.Id) %>
    <%= Html.CheckBoxFor(x => x.IsChecked) %>
