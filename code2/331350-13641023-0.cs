    public class MobileActionFilterAttribute : ActionFilterAttribute
    {
        // The WURFL database contains information about a huge number of devices and mobile browsers.
        // http://wurfl.sourceforge.net/
        // http://wurfl.sourceforge.net/dotnet_index.php
        // http://wurfl.sourceforge.net/help_doc.php
        private static readonly IWURFLManager WurflManager;
        static MobileActionFilterAttribute ()
        {
            IWURFLConfigurer configurer = new ApplicationConfigurer();
            WurflManager = WURFLManagerBuilder.Build(configurer);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.RequestContext.HttpContext.Request;
            // We don't have ARR server for dev environment, so we still need to check to see if the current domain name is the mobile site.
            if (request.Url.AbsoluteUri.StartsWith(SiteConfiguration.Current.MobileSiteAddress, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            // Creates a WURFLRequest object from an ASP.NET HttpRequest object
            WURFLRequest wurflRequest = WURFLRequestFactory.CreateRequest(HttpContext.Current.Request);
            
            // Indicates whether the current user agent string refers to a desktop agent.
            if (wurflRequest.IsDesktopRequest)
                return;
            // Get the information about the device
            IDevice deviceInfo = WurflManager.GetDeviceForRequest(wurflRequest);
            // Tells you if a device is a tablet computer (iPad and similar, regardless of OS)
            bool isTablet = string.Equals(deviceInfo.GetCapability("is_tablet") ?? string.Empty, "true", StringComparison.OrdinalIgnoreCase);
            
            if (isTablet)
            {
                // so we don't show the mobile site for iPad.
                return;
            }
            // Indicates whether the current user agent string refers to a mobile device.
            bool isMobileRequest = wurflRequest.IsMobileRequest;
            // Tells you if a device is wireless or not. Specifically a mobile phone or a PDA are considered wireless devices, a desktop PC or a laptop are not
            bool isWirelessDevice = string.Equals(deviceInfo.GetCapability("is_wireless_device") ?? string.Empty, "true", StringComparison.InvariantCultureIgnoreCase);
            if (isMobileRequest && isWirelessDevice)
            {
                // we can redirect to the mobile site!
                filterContext.Result = new RedirectResult(SiteConfiguration.Current.MobileSiteAddress);
            }
        }
    }
