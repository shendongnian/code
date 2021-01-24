    public void MapCarIdToDepartment(int departmentId, List<Guid> carIds)
    {
        using (var context = new CarContext())
        {
            foreach (var carId in carIds)
            {
                var car = context.DepartmentCars.SingleOrDefault(x => x.CarId == carId);
                if (car == null)
                {
                    car = new DepartmentCar{ CarId = carId };
                    context.DepartmentCars.Add(car);
                }
                car.DepartmentId = departmentId;
            }
            context.SaveChanges();
        }
    }
