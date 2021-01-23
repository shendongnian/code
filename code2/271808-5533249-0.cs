    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
              if(modelType is DateTime || modelType is DateTime?)
                {
                     return  new TimeOfDayModelBinder();
                } 
               return null;
        }
    }
