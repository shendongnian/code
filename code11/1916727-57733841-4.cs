    public void method (RequestModel request)
    {
         var create = new DtoModel();
         MaybeAdd(request.FirstDoc);
         MaybeAdd(request.SecondDoc);
         MaybeAdd(request.ThirdDoc);
         void MaybeAdd(docsModel doc)
         {
             if (doc != null)
             {
                 if (create.docs == null)
                 {
                     create.docs = new List<docsModel>();
                 }
                 create.docs.Add(runFunction(doc));
             }
         }
    }
