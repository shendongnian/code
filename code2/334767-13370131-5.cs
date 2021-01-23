    private DocumentPage FixFixedPage(DocumentPage page)
    {
        if (!(page.Visual is FixedPage))
            return page;
            
        // Create a new ContainerVisual as a new parent for page children
        var cv = new ContainerVisual();
        foreach (var child in ((FixedPage)page.Visual).Children)
        {
            // Make a shallow clone of the child using reflection
            var childClone = (UIElement)child.GetType().GetMethod(
                "MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic
                ).Invoke(child, null);
            // Setting the parent of the cloned child to the created ContainerVisual
            // by using Reflection.
            // WARNING: If we use Add and Remove methods on the FixedPage.Children,
            // for some reason it will throw an exception concerning event handlers
            // after the printing job has finished.
            var parentField = childClone.GetType().GetField(
                "_parent", BindingFlags.Instance | BindingFlags.NonPublic);
            if (parentField != null)
            {
                parentField.SetValue(childClone, null);
                cv.Children.Add(childClone);
            }
        }
        return new DocumentPage(cv, page.Size, page.BleedBox, page.ContentBox);
    }
