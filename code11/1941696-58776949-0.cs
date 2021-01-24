var num = new Book();
var checkNum = num.Price = 10; //these is the values
var checkNum2 = num.Price2 = 20;
var result = new Check();
var checkNum3 = result.Calculate(num);
Console.WriteLine(checkNum3);
# Better names
If you use better names it would be easier to follow.
var book = new Book();
book.Price = 10; //these is the values
book.Price2 = 20;
var check = new Check();
var calculated = result.Calculate(book);
Console.WriteLine(calculated);
# Let's improve
 
## A. (Best?) `Check` is a calulator 
public class Check  // Not a book
{
    public static int Calculate(Book book)
    {
        var p = book.Price;
        var p2 = book.Price2;
        var total = p + p2;
        Console.WriteLine(total);
        return total;
    }
}
(...)
var calculated = Check.Calculated(book); // no: new Check()
## B. If `Check` has a `Book`. 
The `Check` does not *be* a `Book`, it can *have* it. 
public class Product
{
    public string Title { get; set; }
    public int Price { get; set; }
}
public class Book : Product
{
    public string Isbn { get; set; }
    public int Price2 { get; set; }
}
public class Check
{
    private readonly Book book;
    public Check(Book book) 
    {
       this.book = book;  
    }
    public int Calculate() => book.Price + book.Price2;
}
class Program
{
    static void Main(string[] args)
    {
        var book = new Book();
        book.Price = 10;
        book.Price2 = 20;
        var check = new Check(book);
        Console.WriteLine(check .Calculate());
    }
}
#3 C. If `Check` is a `Book`
If `Check` *is* a `Book` it needs to store `Price` and `Price2`. Please consider the following example. 
public class Product
{
    public Product() { }
    public Product(string title, int price)
    {
        Title = title;
        Price = price;
    }
    public string Title { get; set; }
    public int Price { get; set; }
}
public class Book : Product
{
    public Book(Book book) : base(book.Title, book.Price)
    {
        Isbn = book.Isbn;
        Price2 = book.Price2;
    }
    public Book() { }
    public string Isbn { get; set; }
    public int Price2 { get; set; }
}
public class Check : Book
{
    public Check(Book book) : base(book)
    {
        // This should really call Book's contrcutor
    }
    public int Calculate() => Price + Price2;
}
class Program
{
    static void Main(string[] args)
    {
        var b = new Book();
        b.Price = 10;
        b.Price2 = 20;
        var c = new Check(b);
        Console.WriteLine(c.Calculate());
    }
}
