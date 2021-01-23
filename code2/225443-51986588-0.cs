    using System.IO.Compression;
    using System.IO.Packaging;
    
    using (var package = Package.Open( your_Zip/OPC_File_Path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
    {
        // Add the Preview Image to the OPC container
        var imagePart = package.CreatePart( PackUriHelper.CreatePartUri(new Uri("preview.png", UriKind.Relative)), "image/png");
        package.CreateRelationship( imagePart.Uri, TargetMode.Internal, OpcConstants.RelationshipTypes.PREVIEWIMAGE, "preview");
    
        using(var imageStream = imagePart.GetStream( FileMode.Open, FileAccess.Write ))
        {
    	    imageStream.Write( your_preview_Image_Byte_array, 0, your_preview_Image_Byte_array.Length);
        }
    }
       private byte[] GetPreviewImage(System.IO.Packaging.Package package)
       {
            if (!package.RelationshipExists("preview"))
            {
                return null;
            }
            var previewRel = package.GetRelationship("preview");
            var previewUri = PackUriHelper.CreatePartUri(previewRel.TargetUri);
            var previewImagePart = package.GetPart(previewUri);
            using (var previewImageStream = previewImagePart.GetStream(FileMode.Open, FileAccess.Read))
            using (var ms = new MemoryStream())
            {
                previewImageStream.CopyTo(ms);
                return ms.ToArray();
            }
        }
