    public Asset(int assetID)
    {
       using (Data.DicDataContext db = new Data.DicDataContext())
        {
            _asset = _db.Assets.First(a => a.id == assetID);
        }
    }
Please note it is not really a good practice to keep the connection open so take out your reference to the Data.DicDataContext()
this line private Data.DicDataContext _db;
You must have a using in every method. Just like in your New Method.
