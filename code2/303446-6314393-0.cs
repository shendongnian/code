    enum CustEnum
    {
        A=1,
        B,
        C
    }
    class CustomType
    {
        public CustEnum xyz { get; set; }
    }
    ...
    List<CustomType> customTypes = ...    
    var groupedList = customTypes.GroupBy(x => x.xyz).Select(g => g.ToList()).ToList();
