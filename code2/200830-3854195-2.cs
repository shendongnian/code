    Form form = new Form(); // Dummy form for creating a graphics device
    GraphicsDeviceService gds = GraphicsDeviceService.AddRef(form.Handle,
            form.ClientSize.Width, form.ClientSize.Height);
    ServiceContainer services = new ServiceContainer();
    services.AddService<IGraphicsDeviceService>(gds);
    content = new ContentManager(services, "Content");
