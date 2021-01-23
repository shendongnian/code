    ...
    using Visio = Microsoft.Office.Interop.Visio;
    
    namespace RibbonCustomization
    {
       [ComVisible(true)]
       public class Ribbon1 : Office.IRibbonExtensibility
       {
    
          public void ReadShapes(Microsoft.Office.Core.IRibbonControl control)
          {
             ExportElement exportElement;
             ArrayList exportElements = new ArrayList();
    
             Visio.Document currentDocument = Globals.ThisAddIn.Application.ActiveDocument;
             Visio.Pages Pages = currentDocument.Pages;
             Visio.Shapes Shapes;
    
             foreach(Visio.Page Page in Pages)
             {
                Shapes = Page.Shapes;
                foreach (Visio.Shape Shape in Shapes)
                {
                   exportElement = new ExportElement();
                   exportElement.Name = Shape.Master.NameU;
                   exportElement.ID = Shape.ID;               
                   exportElement.Text = Shape.Text;
                   ...
                   // and any other properties you'd like
    
                   exportElements.Add(exportElement);
                }
             }
    ....
