    public static bool IsImage(HttpPostedFileBase imgup)
                {
                    //THIS CONTAINS ALL ALLOWED FORMATS OF THE SELECTED IMAGE
                    string[] formats = new string[] { ".jpg", ".png", ".jpeg", ".bmp" };
    
                    //THIS WILL CHECK IF THE IMAGE IS HAVE ALLOWED FORMAT OR NOT
                    if (imgup.ContentType.Contains("image")&& formats.Any(item => imgup.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase)))
                    {
                        return true;
                    }
                    return false;
                }
