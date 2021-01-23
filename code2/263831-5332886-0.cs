     public IEnumerable<T> GetCars<T>()
        {
            var lst = new List<T>();
            _data.GetTable<Cars>().ToList().ForEach(x =>
            {
                var newCar = Activator.CreateInstance<T>();
                typeof(T).GetProperty("Engine").SetValue(newCar, x.Engine, null);
                typeof(T).GetProperty("Wheel").SetValue(newCar, x.Wheel, null);
                lst.Add(newCar);
            });
            return lst;
        }
