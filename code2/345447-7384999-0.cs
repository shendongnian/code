    public Vehicle_driver Assign(Driver d, Vehicle v, DateTime start, DateTime end) {
      using (MyContext context = new MyContext()) {
        Vehicle_driver assignment = context.CreateObject<Vehicle_driver>();
        assignment.VEHICLE_ID = v.ID;
        assignment.DRIVER_ID = d.ID;
        assignment.SERVICE_START_DATE = start;
        assignment.SERVICE_END_DATE = end;
        context.Vehicle_drivers.AddObject(assignment);
        context.SaveChanges();
        return assignment;
      }
    }
