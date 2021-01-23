    public static void ShowImage(Gdk.Window w, Gtk.Image image)
    {
        w.DrawImage( Style.ForegroundGC( StateType.Normal ),
                         image.ImageProp,             // TRY THIS                              
                         0, 0, image.Pixbuf.Width, image.Pixbuf.Height,
                         image.Pixbuf.Width, image.Pixbuf.Height
        );
    }
