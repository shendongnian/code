    List<IComponent> GetSelectableComponents(IDesignerHost host)
    {
        var components = host.Container.Components;
        var list = new List<IComponent>();
        foreach (IComponent c in components)
            list.Add(c);
        for (var i = 0; i < list.Count; ++i)
        {
            var component1 = list[i];
            if (component1.Site != null)
            {
                var service = (INestedContainer)component1.Site.GetService(
                    typeof(INestedContainer));
                if (service != null && service.Components.Count > 0)
                {
                    foreach (IComponent component2 in service.Components)
                    {
                        if (!list.Contains(component2))
                            list.Add(component2);
                    }
                }
            }
        }
        return list;
    }
