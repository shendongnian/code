    using Visio = Microsoft.Office.Interop.Visio;
    ...
    // Create a new Basic Flowchart diragram ("_U" specifies the US units version).
    Visio.Document docDiagram = app.Documents.Add("BASFLO_U.VST");
    // Get a reference to the Basic Flowchart Shapes Stencle which was opened by
    // the template above.
    Visio.Document docStencle = app.Documents["BasFlo_U.vss"];
    
    // Get the Decision master from the Stencil.
    Visio.Master master = docStencle.Masters["Decision"];
    
    // Get the name of the Decision master
    string masterName = master.Name;
    
    // Export the Icon from the Decision Master. 
    // You could use GetTempFileName here.
    master.ExportIcon(
        @"c:\temp\icom.bmp", 
        (short) Visio.VisMasterProperties.visIconFormatBMP);
