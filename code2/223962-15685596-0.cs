    class ViewFactory
    {
        public static IView GetViewType(string PropertyValue, SomeOtherObject parentControl){
        Assembly assembly = Assembly.GetAssembly(typeof(ViewFactory));
        var types = from type in assembly.GetTypes()
                    where Attribute.IsDefined(type,typeof(ViewTypeAttribute))
                    select type;
        var objectType = types.Select(p => p).
            Where(t => t.GetCustomAttributes(typeof(ViewTypeAttribute), false)
                .Any(att => ((ViewTypeAttribute)att).name.Equals(PropertyValue)));
        IView myObject = (IView)Activator.CreateInstance(objectType.First(),parentControl);
        return myObject;
    }
    }
    [ViewTypeAttribute("PropertyValue", "1.0")]
    class ListboxView : IView
    {
    public ListboxView(FilterDocumentChoseTypeFieldControll parentControl)
    {
    }       
    public override void CreateChildrens()
    {
    }
    }
