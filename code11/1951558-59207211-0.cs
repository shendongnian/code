class Program
{
    static void Main(string[] args)
    {
        var json = "{ \"price\": \"0.002200\" }";
        var data = JsonConvert.DeserializeObject<Data>(json);
        Console.WriteLine(data.Price);
    }
}
class Data
{
    public double Price { get; set; }
}
