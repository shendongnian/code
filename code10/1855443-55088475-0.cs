    public class BusinessLayerBaseNoCSLA<TObject, TParameters>
        where TObject : BusinessLayerBaseNoCSLA<TObject, TParameters> // optional
        where TParameters : BaseParameters
    {
        public virtual void Fetch_Data(TParameters parameters)
        {
            throw new NotWellConfiguredException();
        }
    }
