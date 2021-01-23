    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cities = <data access code>
    
            return View(cities);
        }
    }
        
    @ Page Title='' Language='C#' MasterPageFile='~/Views/Shared/Site.Master' Inherits=System.Web.Mvc.ViewPage<IEnumerable<City>> 
    <select id="ddlCities">
        <% foreach (var item in ViewData.Model.Cities) { %>
            <option value='<%= item.CityID %>'><%= item.CityName %></option>
        <% } %>
    </select>
