         partial class ThisRibbonCollection :    Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
        {
         internal SharedRibbonLibrary.Ribbon1 Ribbon1
         {
             get { return this.GetRibbon<SharedRibbonLibrary.Ribbon1>(); }
         }
        }
