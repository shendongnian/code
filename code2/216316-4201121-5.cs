    MyDataContext db = new MyDataContext();
    Car car = db.Cars.First(c => c.Id == 1);
    car.Name = "Betsy";
    car.UpdatedBy = String.Format("{0}|{1}", car.UpdatedBy, DateTime.Ticks);
    db.SubmitChanges();
    car.UpdatedBy = car.UpdatedBy.Substring(0, car.UpdatedBy.LastIndexOf('|'));
    db.SubmitChanges();
