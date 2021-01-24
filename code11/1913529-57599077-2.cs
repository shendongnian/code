C#
class car
{
    public string name;
    public car()
    {
    }
    public static car[] get_cars()
    {
        car[] cars = new car[2];
        for (int k = 0; k<cars.Length; k++)
        {
            cars[k] = new car();
            cars[k].name = "Car 0" + k;
        }
        return cars;
    }
}
