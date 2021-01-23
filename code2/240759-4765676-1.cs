    ...
    using System.Linq;
    using System.Xml.Linq;
      
    var mthumbs = itm.Elements( nsr + "thumbnail" )
                     .Select( e => new MediaThumbnail
                      {
                         mediaThumbnailUrl = string.Format( "{0}", e.Attribute("url" ),
                         mediaThumbnailHeight = string.Format( "{0}",e.Attribute("height" ),
                         mediaThumbnailWidth = string.Format( "{0}",e.Attribute("width" ),
                         mediaThumbnailTime = string.Format( "{0}", e.Attribute("time" )
                      })
                     .ToList();
