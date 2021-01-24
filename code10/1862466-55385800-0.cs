    using System;
    using System.Web;
    public class UserImageHandler : IHttpHandler {
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "image/png"; // or image/jpg, image/bmp, ...
            var image = FetchImageFromDatabase(context.User.Identity.Name); // your logic for fetching the image from the database
                // You could also return a default image here, if the user has not selected one.
            context.Response.Write(image); // Write the binary data to the response stream.
        }
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
