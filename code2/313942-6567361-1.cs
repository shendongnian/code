    var  ppApp = new Microsoft.Office.Interop.PowerPoint.Application();
    ppApp.Visible = MsoTriState.msoTrue;
    var ppPresens = ppApp.Presentations;
    var  objPres = ppPresens.Open(e.FullPath, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
    var  objSlides = objPres.Slides;    								    								    
    //Run the Slide show
    var objSSS = objPres.SlideShowSettings;    
    objSSS.Run();
    var objSSWs = ppApp.SlideShowWindows;
    while (objSSWs.Count >= 1) 
       System.Threading.Thread.Sleep(1000);
    objPres.Close();
    ppApp.Quit();
