    public void method (RequestModel request)
    {
         var create = new DtoModel { docs = new List<docsModel>() };
         MaybeAdd(request.FirstDoc);
         MaybeAdd(request.SecondDoc);
         MaybeAdd(request.ThirdDoc);
         void MaybeAdd(docsModel doc)
         {
             if (doc != null)
             {
                 create.docs.Add(runFunction(doc));
             }
         }
    }
