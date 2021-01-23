    class CarModel {
        public CarModel(string name){
            CarModelName = name;
            CarSubModels = new IList<CarModel>();
        }
        public string CarModelName {get;set;}
        public IList<CarModel> CarSubModels {get;private set;}
        public void AddSubModel(CarModel car){
            if (car == null)
                throw new ArgumentNullException("car");
            if (!CarSubModels.Contains(car))
                CarSubModels.Add(car);
        }
        public void RemoveSubModel(CarModel car){
            if (car == null)
                throw new ArgumentNullException("car");
            if (CarSubModels.Contains(car))
                CarSubModels.Remove(car);
        }
        
        public void Print(int level=0){
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
                sb.Append(' ');
            sb.Append(CarModelName);
            string line = sb.ToString();
            Console.Writeline(line);
            foreach (CarModel car in CarSubModels)
                car.Print(level+1);            
        }
 
    }
