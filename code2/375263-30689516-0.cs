    //Add images from file name to list
    if (file.Extension.Contains(".bmp")){
        imageList.Images.Add(Bitmap.FromFile(string.Format("{0}", file.FullName)));
        listView_Families.LargeImageList = imageList;
    }
