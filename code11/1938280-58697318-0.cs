csharp
private void ReplaceImageIds()
{
   foreach (var image in Image.GetImagesFromText(HTMLBody))
   {
      var imageTag = $"<img src = \"cid:{image.Id.ToString()}\"/>";
      var attachment = _mailItem.Attachments.Add(image.FilePath, OlAttachmentType.olEmbeddeditem, 0, image.Name);
      attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x370E001F", "image/jpg");
      attachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001F", image.Id.ToString());
      HTMLBody = HTMLBody.Replace($"ImageId={image.Id.ToString()}", imageTag);
      }
   }
