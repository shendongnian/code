    internal void CreateMainPanel()
    {
        Panel main = new Panel(){CssClass="form"};
        UpdatePanel All = new UpdatePanel();
        All.ContentTemplateContainer.Controls.Add(main);
        //form is a static panel reference which I use inside the class
        form = main;
    }
