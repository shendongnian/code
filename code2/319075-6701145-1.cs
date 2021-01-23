    public ActionResult Create(WidgetViewModel model)
    {
        Widget widget = new Widget{
             Name = model.Name,
             WidgetType = yourManager.GetWidgetTypeByID(model.WigetTypeId);
        };
    
        yourManager.Create(widget);
    
        //...
    }
