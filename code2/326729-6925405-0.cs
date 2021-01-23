    public void Foo(FlowDocumentScrollViewer viewer) {
        TextPointer t = viewer.Selection.Start;
        FrameworkContentElement e = t.Parent as FrameworkContentElement;
        if (e != null)
             e.BringIntoView();
    }
