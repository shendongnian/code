            context.Response.ContentType = "image/jpeg";
            //saving bitmap image
            returnImage.Save(context.Response.OutputStream,
                System.Drawing.Imaging.ImageFormat.Jpeg);
            returnImage.Dispose();
