    ClientContext spContext = ClientContext.Current;
    File.OpenBinaryDirect(spContext, spContext.Web.ServerRelativeUrl + "/lists/[ListName]/Attachments/[ItemID]/[File Name]", (w, f) =>
            {
                var foo = f.Stream;
            
            }, (q, w) => { 
                handler(this, new Exception(w.Message)); 
            });
