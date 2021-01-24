       static void Main(string[] args)
        {
          List<Car> cars = new List<Car>();
          cars.Add(new Car { Make = "Honda", Model = "Accord", Color = "blue" });
          cars.Add(new Car { Make = "Dodge", Model = "Caravan", Color = "green" });
          cars.Add(new Car { Make = "Ford", Model = "Crown Victoria", Color = "red" });
          cars.Add(new Car { Make = "Honda", Model = "Civic", Color = "blue" });
          var carGroups = cars.GroupBy(c => c.Color);
          List<ColorGroup> obj = new List<ColorGroup>();
          foreach (var group in carGroups)
          {
            ColorGroup cg = new ColorGroup();
            cg.Color = group.Key;
            foreach (var item in group)
            {
              cg.Cars.Add(item);
            }
            obj.Add(cg);
          }
          var s = JsonConvert.SerializeObject(obj);
    
        }
      }
      [Serializable()]
      public class Car {
        public string Make { get; set; }
        public string Model { get; set; }
        [XmlIgnore]
        [ScriptIgnore]
        public string Color { get; set; }
      }
      public class ColorGroup {
        public ColorGroup(){
          Cars = new List<Car>();
        }
        public string Color { get; set; }
        public List<Car> Cars { get; set; }
      }
