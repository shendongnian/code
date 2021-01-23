    public class SomethingThatUsesWidgets
    {    
        private readonly IIndex<WidgetType,Widget> _widgetFactory;
        public SomethingThatUsesWidgets(IIndex<WidgetType,Widget> widgetFactory)
        {
            if (widgetFactory == null) throw ArgumentNullException("widgetFactory");
            _widgetFactory = widgetFactory;
        }
        public void DoSomething()
        {
            // Simple usage:
            Widget widget = widgetFactory[WidgetType.Whizbang];
            // Safe Usage:
            Widget widget2 = null;
            if(widgetFactory.TryGetValue(WidgetType.Sprocket, out widget2))
            {
                // do stuff
            }
        }
    }
