    public async Task<string> RenderViewComponent(string viewComponent, object args) {
    var sp = HttpContext.RequestServices;
    var helper = new DefaultViewComponentHelper(
        sp.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
        HtmlEncoder.Default,
        sp.GetRequiredService<IViewComponentSelector>(),
        sp.GetRequiredService<IViewComponentInvokerFactory>(),
        sp.GetRequiredService<IViewBufferScope>());
    using (var writer = new StringWriter()) {
        var context = new ViewContext(ControllerContext, NullView.Instance, ViewData, TempData, writer, new HtmlHelperOptions());
        helper.Contextualize(context);
        var result = await helper.InvokeAsync(viewComponent, args);
        result.WriteTo(writer, HtmlEncoder.Default);
        await writer.FlushAsync();
        return writer.
    }
    }
