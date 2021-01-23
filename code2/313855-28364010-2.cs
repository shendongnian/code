    private void SetHeight(ListView listView, int height)
    {
        ImageList imgList = new ImageList();
        imgList.ImageSize = new Size(1, height);
        listView.SmallImageList = imgList;
    }
