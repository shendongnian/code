        public void RenderImage(ImageRenderInfo info)
        {
            PdfImageObject image = info.GetImage();
            Parser.Matrix matrix = info.GetImageCTM();
            var fileType = image.GetFileType();
            ImageFormat format;
            switch (fileType)
            {//you may add more types here
                case "jpg":
                case "jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case "pnt":
                    format = ImageFormat.Png;
                    break;
                case "bmp":
                    format = ImageFormat.Bmp;
                    break;
                case "tiff":
                    format = ImageFormat.Tiff;
                    break;
                case "gif":
                    format = ImageFormat.Gif;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }
            var pic = image.GetDrawingImage();
            var x = matrix[Parser.Matrix.I31];
            var y = matrix[Parser.Matrix.I32];
            var width = matrix[Parser.Matrix.I11];
            var height = matrix[Parser.Matrix.I22];
            if (x < <some value> && y < <some value>)
            {
                return;//ignore these images
            }
            pic.Save(<path and name>, format);
    }
