`
public class Sides
{
    // Public properties
    public int Adjacent { get; set; }
    public int Opposite { get; set; }
    public double Hypotenuse { get; set; }
    // Constructor 
    public Sides(int adjacent, int opposite, double hypotenuse)
    {
        this.Adjacent = adj;
        this.Opposite = opposite;
        this.Hypotenuse = hypotenuse;
    }
}
`
If you want to only allow setting the properties from within the class itself, you can make the setter `private`:
`
public class Sides
{
    // Public properties
    public int Adjacent { get; private set; }
    public int Opposite { get; private set; }
    public double Hypotenuse { get; private set; }
    // Constructor 
    public Sides(int adjacent, int opposite, double hypotenuse)
    {
        this.Adjacent = adj;
        this.Opposite = opposite;
        this.Hypotenuse = hypotenuse;
    }
}
`
Also note that it is not necessary to include the `type` in a variable's name.
