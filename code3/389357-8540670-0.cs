    [ControllerAction]
    public void getLocations( int userId ) {
        ViewData["UserId"] = userId;
        RenderView("GetLocations");
    }
