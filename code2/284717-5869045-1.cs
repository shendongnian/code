    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;
    
    /// <summary>
    /// Summary description for HomePageConstraint
    /// </summary>
    public class HomePageConstraint : IRouteConstraint
    {
    	public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return GetRegions().Any(x => x.ToLower() == values[parameterName].ToString().ToLower());
            
        }
    
    
        private List<string> GetRegions()
        {
            List<string> set = new List<string>();
            set.Add("National");
            set.Add("BC");
            set.Add("AB");
            set.Add("SASK");
            set.Add("MAN");
            set.Add("ON");
            set.Add("QC");
            set.Add("Maritimes");
            set.Add("NL");
    
            return set;
        
        }
    }
