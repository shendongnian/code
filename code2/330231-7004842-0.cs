    private void SomeMethod()
    {
        var myClickDelegate = (EventHandler)delegate { clicked(z2, null); };
        PicBx[z].Click += myClickDelegat;
        //Do extra work
        PicBx[z].Click -= mayClickDelegat;
    }
