    public ActionResult MenuItemCreated(int id)
    {
        var menuItem = _someRepository.GetMenuItem(id);
        ...
    }
