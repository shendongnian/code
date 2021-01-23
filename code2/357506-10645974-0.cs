public class Measurement
{
    [Key,
        Column("Id"),
        DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public DateTime MTime { get; set; }
    public virtual Unit Value { get; set; }
}
[ComplexType]
public class Unit
{
    protected Unit()
    {
    }
    protected Unit(double value)
    {
        Value = value;
    }
    public double Value { get; set; }
    public string TypeName { get; set; }
}
public class Celsius : Unit
{
    public Celsius(double value) : base(value)
    {
        TypeName = "Celsius";
    }
    public static explicit operator Kelvin(Celsius c)
    {
        return new Kelvin(c.Degrees + 273.16d);
    }
    public double Degrees
    {
        get { return this.Value; }
    }
}
public class Kelvin : Unit
{
    public Kelvin(double value) : base(value)
    {
        TypeName = "Kelvin";
    }
    public static explicit operator Celsius(Kelvin k)
    {
        return new Celsius(k.Degrees - 273.16d);
    }
    public double Degrees
    {
        get { return this.Value; }
    }
}
