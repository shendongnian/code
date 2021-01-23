    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.DataSourcesGDB;
    …
    IWorkspaceFactory wsFactory = new FileGDBWorkspaceFactory();
    IWorkspace ws = wsFactory.OpenFromFile(@"\path\to\your\file.gdb", hWnd);
