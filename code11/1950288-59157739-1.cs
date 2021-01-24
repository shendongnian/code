    public static MyMainFunc(string nameOfCar)
    {
        string getNameOfCar = "", tyreNameOfCar = "";
        if (Enum.TryParse(nameOfCar, out CarCollection carType))
        {
            switch (carType)
            {
                case CarCollection.Audi:
                    getNameOfCar = "Audi X";
                    tyreNameOfCar = "Ceat";
                    break;
                case CarCollection.BMW:
                    getNameOfCar = "BMW Y";
                    tyreNameOfCar = "ABCD";
                    break;
            }
        }
        // more logic 
    }
