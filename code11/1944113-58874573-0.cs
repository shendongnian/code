    Car car = new Car();
    car.type = "BMW";
    //string json = JsonUtility.ToJson(car);
    //System.Object @object = JsonUtility.FromJson<System.Object>(json);
    System.Object @object = car;
    car = (Car)@object;
    Debug.Log(car.type);
