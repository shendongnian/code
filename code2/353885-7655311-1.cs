    var visioApp = new Visio.Application();
    // Load the UML Statechart stencil (docked)
    var stencil_open_flags = Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDocked;
    var umlStencil = visioApp.Documents.OpenEx(@"UMLSTA_M.vss", (short)stencil_open_flags);
    // create a new empty doc based on the UML Model Template
    var doc = visioApp.Documents.AddEx("UMLMOD_U.VST", Visio.VisMeasurementSystem.visMSUS, 0, 0); 
    var page = doc.Pages.Add();
    var watermark = page.Shapes["Watermark Title"];
    var LockTextEdit_cell = watermark.CellsU["LockTextEdit"];
    LockTextEdit_cell.FormulaForceU = "GUARD(0)";
    watermark.Text = "MyTitle";
    LockTextEdit_cell.FormulaForceU = "GUARD(1)";
            
    // Find the masters we need
    var state_master = umlStencil.Masters["State"];
    var transition_master = umlStencil.Masters["Transition"];
    // Drop the masters into the page
    var s1 = page.Drop(state_master, 5.0, 5.0);
    var s2 = page.Drop(state_master, 1.0, 1.0);
    var transition = page.Drop(transition_master, 3.0, 3.0);
