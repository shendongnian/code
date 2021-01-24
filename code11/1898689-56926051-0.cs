[ViewContext]
public ViewContext ViewContext { get; set; }
2. Right before you call `_helper.InvokeAsync`, add this line of code
((IViewContextAware)_helper).Contextualize(ViewContext);
Hope this helps!
