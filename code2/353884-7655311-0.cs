    using Visio = Microsoft.Office.Interop.Visio;
    namespace DemoVisioCSharp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var visioApp = new Visio.Application();
                var stencil_open_flags = Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDocked;
                var umlStencil = visioApp.Documents.OpenEx(@"UMLSTA_M.vss", (short)stencil_open_flags);
                var doc = visioApp.Documents.Add(""); // create a new empty doc
                var page = doc.Pages.Add();
                var state_master = umlStencil.Masters["State"];
                var transition_master = umlStencil.Masters["Transition"];
                var s1 = page.Drop(state_master, 5.0, 5.0);
                var s2 = page.Drop(state_master, 1.0, 1.0);            
                var transition = page.Drop(transition_master, 3.0, 3.0);
            }
        }
    }
