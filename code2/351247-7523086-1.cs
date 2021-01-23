    public class SomethingThatUsesWidgets
    {    
        public SomethingThatUsesWidgets(IIndex<WidgetType,Widget> factory)
        {
            var widget = widgetFactory[WidgetType.Whizbang];
            Widget w2 = null;
            if(widgetFactory.TryGetValue(WidgetType.Sprocket, out w2))
            {
                // do stuff
            }
        }
    }
