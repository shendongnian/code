    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.DataSourcesGDB;
    …
    IWorkspaceFactory wsFactory = new FileGDBWorkspaceFactory();  // (see P.S. below)
    IWorkspace ws = wsFactory.OpenFromFile(@"\path\to\your\file.gdb", hWnd);
