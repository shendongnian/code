    public static class DataPortal
    {
        public static TObject FetchData<TObject, TParameters>(TParameters criteria) 
            where TObject : BusinessLayerBaseNoCSLA<TObject, TParameters>, new()
            where TParameters : BaseParameters
        {
            var result = new TObject();
            //result.Fetch_Data((BaseParameters)criteria);
            // Note: no need to cast criteria!
            result.Fetch_Data(criteria);
            return result;
        }
    }
