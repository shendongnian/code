    public void VehicleConverter(IEnumerable obj)
    {
         IEnumerable<MyBaseClass> enumerable = obj.Cast<MyBaseClass>();
         List<MyBaseClass> list = enumerable.ToList();
    }
