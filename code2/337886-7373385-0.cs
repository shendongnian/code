    internal ITextBuffer GetBufferAt(string filePath)
    {
      var componentModel = (IComponentModel)GetService(typeof(SComponentModel));
      var editorAdapterFactoryService = componentModel.GetService<IVsEditorAdaptersFactoryService>();
      var serviceProvider = new Microsoft.VisualStudio.Shell.ServiceProvider(MetaSharpPackage.OleServiceProvider);
      IVsUIHierarchy uiHierarchy;
      uint itemID;
      IVsWindowFrame windowFrame;
      if (VsShellUtilities.IsDocumentOpen(
        serviceProvider,
        filePath,
        Guid.Empty,
        out uiHierarchy,
        out itemID,
        out windowFrame))
      {
        IVsTextView view = VsShellUtilities.GetTextView(windowFrame);
        IVsTextLines lines;
        if (view.GetBuffer(out lines) == 0)
        {
          var buffer = lines as IVsTextBuffer;
          if (buffer != null)
            return editorAdapterFactoryService.GetDataBuffer(buffer);
        }
      }
      return null;
    }
