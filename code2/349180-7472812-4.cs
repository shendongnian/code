    <%@ Page 
        Title="" 
        Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master" 
        Inherits="System.Web.Mvc.ViewPage<EventListing.Models.MyViewModel>" 
    %>
    <%= Html.DropDownListFor(
        x => x.SelectedTimeZone, 
        Model.TimeZones, 
        "Select Timezone"
    ) %>
