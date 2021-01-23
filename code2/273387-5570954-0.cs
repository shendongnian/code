    public class GetCarsOptions
    {
        public int MakeId {get;set;}
        public int ModelId {get;set;}
        public int Year {get;set;}
        public int DealershipId {get;set;}
    }
    List<Cars> GetCars(GetCarsOptions options)
    {
        ValidateOptions(options); // make sure the values all make sense.
    }
