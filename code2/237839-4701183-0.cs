     public void Load(int fFullyAvailable, IMoniker pmk, IBindCtx pbc, uint grfMode)
     {
         if (pmk == null)
             throw new ArgumentNullException("pmk");
         string url;
         pmk.GetDisplayName(null, null, out url);
         // Use the moniker to download the persisted data
         // and obtain an IStream on that data
         Guid iid = InterfaceID.IID_IStream;
         object pStream;
         pmk.BindToStorage(pbc, null, ref iid, out pStream);
         // do whatever you want with the data inside pStream
         ...
    }
