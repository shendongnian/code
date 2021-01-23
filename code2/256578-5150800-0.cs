    @using System
    @using uComponents.Core
    @using uComponents.Core.uQueryExtensions
    @using System.Linq
    @{
       var n = uQuery.GetCurrentNode();
       var pictures = n.GetProperty("pictures").Value;
       if(pictures.Length > 0)
       {
         var pictureNodes = pictures.Split(',');
     
         foreach (var pictureNode in pictureNodes)
         {
           var node = uQuery.GetNode(Convert.ToInt32(pictureNode));
           var photoId = node.GetProperty("picture").Value;
           var photo = uQuery.GetMedia(Convert.ToInt32(photoId));
           var crop = photo.GetImageCropperUrl("imageCropper", "wide");
           <li><a rel="photos" href="@crop" title="@node.GetProperty("title").Value">
           <img src="@crop" height="150px" width="150px" class="shadow hovershadow"></a></li>
         }
       }
       else
       {
         <li>Pictures coming soon!</li>
       }
    }
