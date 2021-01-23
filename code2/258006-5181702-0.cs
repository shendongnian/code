    Dictionary<Point, MouseEventInfo> dict = new Dictionary<Point, MouseEventInfo>();
    /// see given link to find the correct way to get this kind of event
    public void mouse_event(....)
    {
       /// get mouse coordinates
       /// create point struct
       /// check if point exists in DICT
    
       /// no - add new MouseEventInfo at Point
       /// yes - access MouseEventInfo object and increase a value according to the event
    }
    public void onFinished()
    {
         /// create new bitmap/image - width/height according to your screen resultion
         /// iterate through all MouseEventInfo objects and draw any information
    }
    /// stores mouse event info for a point
    class MouseEventInfo
    {
          Point p;
          int moved=0;
          int clicked=0;
          int doubleClicked=0;
    }
