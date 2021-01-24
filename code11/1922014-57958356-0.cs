    class VM
    {
        Viewer view;
        public VM()
        {
           view = new Viewer();
        }
        public UIElement MyControl
        {
           get {return view.GetUIElement(); }//Set is not necessary
        }
    }
