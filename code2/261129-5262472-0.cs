     public static IEnumerable<Component> GetDescendants(this Composite composite)
        {
            foreach(var child in composite.Children)
            {
                yield return child;
                if(!(child is Composite))
                   continue;
                
                foreach (var subChild in ((Composite)child).GetDescendants())
                   yield return subChild;
            }
        }
