ref1.ref2.ref3.member
If ref1 or ref2 or ref3 is null, then you'll get a `NullReferenceException`. If you want to solve the problem, then find out which one is null by rewriting the expression to its simpler equivalent:
var r1 = ref1;
var r2 = r1.ref2;
var r3 = r2.ref3;
r3.member
Specifically, in `HttpContext.Current.User.Identity.Name`, the `HttpContext.Current` could be null, or the `User` property could be null, or the `Identity` property could be null.
###Indirect
public class Person 
{
    public int Age { get; set; }
}
public class Book 
{
    public Person Author { get; set; }
}
public class Example 
{
    public void Foo() 
    {
        Book b1 = new Book();
        int authorAge = b1.Author.Age; // You never initialized the Author property.
                                       // there is no Person to get an Age from.
    }
}
If you want to avoid the child (Person) null reference, you could initialize it in the parent (Book) object's constructor.
###Nested Object Initializers
The same applies to nested object initializers:
Book b1 = new Book 
{ 
   Author = { Age = 45 } 
};
This translates to
Book b1 = new Book();
b1.Author.Age = 45;
While the `new` keyword is used, it only creates a new instance of `Book`, but not a new instance of `Person`, so the `Author` the property is still `null`.
###Nested Collection Initializers
public class Person 
{
    public ICollection<Book> Books { get; set; }
}
public class Book 
{
    public string Title { get; set; }
}
The nested collection `Initializers` behave the same:
Person p1 = new Person 
{
    Books = {
         new Book { Title = "Title1" },
         new Book { Title = "Title2" },
    }
};
This translates to
Person p1 = new Person();
p1.Books.Add(new Book { Title = "Title1" });
p1.Books.Add(new Book { Title = "Title2" });
The `new Person` only creates an instance of `Person`, but the `Books` collection is still `null`. The collection `Initializer` syntax does not create a collection
for `p1.Books`, it only translates to the `p1.Books.Add(...)` statements.
###Array
int[] numbers = null;
int n = numbers[0]; // numbers is null. There is no array to index.
###Array Elements
Person[] people = new Person[5];
people[0].Age = 20 // people[0] is null. The array was allocated but not
                   // initialized. There is no Person to set the Age for.
###Jagged Arrays
long[][] array = new long[1][];
array[0][0] = 3; // is null because only the first dimension is yet initialized.
                 // Use array[0] = new long[2]; first.
###Collection/List/Dictionary
Dictionary<string, int> agesForNames = null;
int age = agesForNames["Bob"]; // agesForNames is null.
                               // There is no Dictionary to perform the lookup.
###Range Variable (Indirect/Deferred)
public class Person 
{
    public string Name { get; set; }
}
var people = new List<Person>();
people.Add(null);
var names = from p in people select p.Name;
string firstName = names.First(); // Exception is thrown here, but actually occurs
                                  // on the line above.  "p" is null because the
                                  // first element we added to the list is null.
###Events
public class Demo
{
    public event EventHandler StateChanged;
    
    protected virtual void OnStateChanged(EventArgs e)
    {        
        StateChanged(this, e); // Exception is thrown here 
                               // if no event handlers have been attached
                               // to StateChanged event
    }
}
###Bad Naming Conventions:
If you named fields differently from locals, you might have realized that you never initialized the field. 
public class Form1
{
    private Customer customer;
    
    private void Form1_Load(object sender, EventArgs e) 
    {
        Customer customer = new Customer();
        customer.Name = "John";
    }
    
    private void Button_Click(object sender, EventArgs e)
    {
        MessageBox.Show(customer.Name);
    }
}
This can be solved by following the convention to prefix fields with an underscore:
    private Customer _customer;
###ASP.NET Page Life cycle:
public partial class Issues_Edit : System.Web.UI.Page
{
    protected TestIssue myIssue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             // Only called on first load, not when button clicked
             myIssue = new TestIssue(); 
        }
    }
        
    protected void SaveButton_Click(object sender, EventArgs e)
    {
        myIssue.Entry = "NullReferenceException here!";
    }
}
###ASP.NET Session Values
// if the "FirstName" session value has not yet been set,
// then this line will throw a NullReferenceException
string firstName = Session["FirstName"].ToString();
###ASP.NET MVC empty view models 
If the exception occurs when referencing a property of `@Model` in an `ASP.NET MVC View`, you need to understand that the `Model` gets set in your action method, when you `return` a view. When you return an empty model (or model property) from your controller, the exception occurs when the views access it:
// Controller
public class Restaurant:Controller
{
    public ActionResult Search()
    {
        return View();  // Forgot the provide a Model here.
    }
}
// Razor view 
@foreach (var restaurantSearch in Model.RestaurantSearch)  // Throws.
{
}
    
<p>@Model.somePropertyName</p> <!-- Also throws -->
###WPF Control Creation Order and Events
`WPF` controls are created during the call to `InitializeComponent` in the order they appear in the visual tree.  A `NullReferenceException` will be raised in the case of early-created controls with event handlers, etc. , that fire during `InitializeComponent` which reference late-created controls.
For example :
<Grid>
    <!-- Combobox declared first -->
    <ComboBox Name="comboBox1" 
              Margin="10"
              SelectedIndex="0" 
              SelectionChanged="comboBox1_SelectionChanged">
       <ComboBoxItem Content="Item 1" />
       <ComboBoxItem Content="Item 2" />
       <ComboBoxItem Content="Item 3" />
    </ComboBox>
        
    <!-- Label declared later -->
    <Label Name="label1" 
           Content="Label"
           Margin="10" />
</Grid>
Here `comboBox1` is created before `label1`. If `comboBox1_SelectionChanged` attempts to reference `label1, it will not yet have been created.
private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
    label1.Content = comboBox1.SelectedIndex.ToString(); // NullReference here!!
}
Changing the order of the declarations in the `XAML` (i.e., listing `label1` before `comboBox1`, ignoring issues of design philosophy, would at least resolve the `NullReferenceException` here.
### Cast with `as`
var myThing = someObject as Thing;
This doesn't throw an `InvalidCastException` but returns a `null` when the cast fails (and when `someObject` is itself null). So be aware of that.
### LINQ `FirstOrDefault()` and `SingleOrDefault()`
The plain versions `First()` and `Single()` throw exceptions when there is nothing. The "OrDefault" versions return null in that case. So be aware of that.
###foreach
`foreach` throws when you try to iterate null collection. Usually caused by unexpected `null` result from methods that return collections.
List<int> list = null;    
foreach(var v in list) { } // exception
More realistic example - select nodes from XML document. Will throw if nodes are not found but initial debugging shows that all properties valid:
foreach (var node in myData.MyXml.DocumentNode.SelectNodes("//Data"))
---
#Ways to Avoid
###Explicitly check for `null` and ignore null values.
If you expect the reference sometimes to be null, you can check for it being `null` before accessing instance members:
void PrintName(Person p)
{
    if (p != null) 
    {
        Console.WriteLine(p.Name);
    }
}
###Explicitly check for `null` and provide a default value.
Methods call you expect to return an instance can return `null`, for example when the object being sought cannot be found. You can choose to return a default value when this is the case:
string GetCategory(Book b) 
{
    if (b == null)
        return "Unknown";
    return b.Category;
}
###Explicitly check for `null` from method calls and throw a custom exception.
You can also throw a custom exception, only to catch it in the calling code:
string GetCategory(string bookTitle) 
{
    var book = library.FindBook(bookTitle);  // This may return null
    if (book == null)
        throw new BookNotFoundException(bookTitle);  // Your custom exception
    return book.Category;
}
###Use `Debug.Assert` if a value should never be `null`, to catch the problem earlier than the exception occurs.
When you know during development that a method maybe can, but never should return `null`, you can use `Debug.Assert()` to break as soon as possible when it does occur:
string GetTitle(int knownBookID) 
{
    // You know this should never return null.
    var book = library.GetBook(knownBookID);  
    // Exception will occur on the next line instead of at the end of this method.
    Debug.Assert(book != null, "Library didn't return a book for known book ID.");
    // Some other code
    return book.Title; // Will never throw NullReferenceException in Debug mode.
}
Though this check [will not end up in your release build](https://stackoverflow.com/questions/3021538/debug-assert-appears-in-release-mode), causing it to throw the `NullReferenceException` again when `book == null` at runtime in release mode.
###Use `GetValueOrDefault()` for `nullable` value types to provide a default value when they are `null`.
DateTime? appointment = null;
Console.WriteLine(appointment.GetValueOrDefault(DateTime.Now));
// Will display the default value provided (DateTime.Now), because appointment is null.
appointment = new DateTime(2022, 10, 20);
Console.WriteLine(appointment.GetValueOrDefault(DateTime.Now));
// Will display the appointment date, not the default
###Use the null coalescing operator: `??` [C#] or `If()` [VB].
The shorthand to providing a default value when a `null` is encountered:
IService CreateService(ILogger log, Int32? frobPowerLevel)
{
   var serviceImpl = new MyService(log ?? NullLog.Instance);
 
   // Note that the above "GetValueOrDefault()" can also be rewritten to use
   // the coalesce operator:
   serviceImpl.FrobPowerLevel = frobPowerLevel ?? 5;
}
###Use the null condition operator: `?.` or `?[x]` for arrays (available in C# 6 and VB.NET 14):
This is also sometimes called the safe navigation or Elvis (after its shape) operator. If the expression on the left side of the operator is null, then the right side will not be evaluated, and null is returned instead. That means cases like this:
var title = person.Title.ToUpper();
If the person does not have a title, this will throw an exception because it is trying to call `ToUpper` on a property with a null value.
In `C# 5` and below, this can be guarded with:
var title = person.Title == null ? null : person.Title.ToUpper();
Now the title variable will be null instead of throwing an exception. C# 6 introduces a shorter syntax for this:
var title = person.Title?.ToUpper();
This will result in the title variable being `null`, and the call to `ToUpper` is not made if `person.Title` is `null`.
Of course, you _still_ have to check `title` for null or use the null condition operator together with the null coalescing operator (`??`) to supply a default value:
// regular null check
int titleLength = 0;
if (title != null)
    titleLength = title.Length; // If title is null, this would throw NullReferenceException
    
// combining the `?` and the `??` operator
int titleLength = title?.Length ?? 0;
Likewise, for arrays you can use `?[i]` as follows:
int[] myIntArray=null;
var i=5;
int? elem = myIntArray?[i];
if (!elem.HasValue) Console.WriteLine("No value");
This will do the following: If `myIntArray` is null, the expression returns null and you can safely check it. If it contains an array, it will do the same as:
`elem = myIntArray[i];` and returns the `i<sup>th</sup>` element.
###Use null context (available in C# 8):
Introduced in `C# 8` there null context's and nullable reference types perform static analysis on variables and provides a compiler warning if a value can be potentially null or have been set to null. The nullable reference types allows types to be explicitly allowed to be null.
The nullable annotation context and nullable warning context can be set for a project using the `Nullable` element in your `csproj` file. This element configures how the compiler interprets the nullability of types and what warnings are generated. Valid settings are:
- enable: The nullable annotation context is enabled. The nullable warning context is enabled. Variables of a reference type, string for example, are non-nullable. All nullability warnings are enabled.
- disable: The nullable annotation context is disabled. The nullable warning context is disabled. Variables of a reference type are oblivious, just like earlier versions of C#. All nullability warnings are disabled.
- safeonly: The nullable annotation context is enabled. The nullable warning context is safeonly. Variables of a reference type are nonnullable. All safety nullability warnings are enabled.
- warnings: The nullable annotation context is disabled. The nullable warning context is enabled. Variables of a reference type are oblivious. All nullability warnings are enabled.
- safeonlywarnings: The nullable annotation context is disabled. The nullable warning context is safeonly.
        Variables of a reference type are oblivious. All safety nullability warnings are enabled.
A nullable reference type is noted using the same syntax as nullable value types: a `?` is appended to the type of the variable.
### Special techniques for debugging and fixing null derefs in iterators
`C#` supports "iterator blocks" (called "generators" in some other popular languages).  Null dereference exceptions can be particularly tricky to debug in iterator blocks because of deferred execution:
public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
{
    for (int i = 0; i < count; ++i)
    yield return f.MakeFrob();
}
...
FrobFactory factory = whatever;
IEnumerable<Frobs> frobs = GetFrobs();
...
foreach(Frob frob in frobs) { ... }
If `whatever` results in `null` then `MakeFrob` will throw.  Now, you might think that the right thing to do is this:
// DON'T DO THIS
public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
{
   if (f == null) 
      throw new ArgumentNullException("f", "factory must not be null");
   for (int i = 0; i < count; ++i)
      yield return f.MakeFrob();
}
Why is this wrong?  Because the iterator block does not actually *run* until the `foreach`!  The call to `GetFrobs` simply returns an object which *when iterated* will run the iterator block.
By writing a null check like this you prevent the null dereference, but you move the null argument exception to the point of the *iteration*, not to the point of the *call*, and that is *very confusing to debug*. 
The correct fix is:
// DO THIS
public IEnumerable<Frob> GetFrobs(FrobFactory f, int count)
{
   // No yields in a public method that throws!
   if (f == null) 
       throw new ArgumentNullException("f", "factory must not be null");
   return GetFrobsForReal(f, count);
}
private IEnumerable<Frob> GetFrobsForReal(FrobFactory f, int count)
{
   // Yields in a private method
   Debug.Assert(f != null);
   for (int i = 0; i < count; ++i)
        yield return f.MakeFrob();
}
That is, make a private helper method that has the iterator block logic, and a public surface method that does the null check and returns the iterator.  Now when `GetFrobs` is called, the null check happens immediately, and then `GetFrobsForReal` executes when the sequence is iterated.
If you examine the reference source for `LINQ` to Objects you will see that this technique is used throughout. It is slightly more clunky to write, but it makes debugging nullity errors much easier.  **Optimize your code for the convenience of the caller, not the convenience of the author**.
###A note on null dereferences in unsafe code
`C#` has an "unsafe" mode which is, as the name implies, extremely dangerous because the normal safety mechanisms which provide memory safety and type safety are not enforced. **You should not be writing unsafe code unless you have a thorough and deep understanding of how memory works**. 
In unsafe mode, you should be aware of two important facts:
* dereferencing a null **pointer** produces the same exception as dereferencing a null **reference**
* dereferencing an invalid non-null pointer **can** produce that exception
 in some circumstances
To understand why that is, it helps to understand how .NET produces null dereference exceptions in the first place. (These details apply to .NET running on Windows; other operating systems use similar mechanisms.)
Memory is virtualized in `Windows`; each process gets a virtual memory space of many "pages" of memory that are tracked by the operating system. Each page of memory has flags set on it which determine how it may be used: read from, written to, executed, and so on.  The *lowest* page is marked as "produce an error if ever used in any way".  
Both a null pointer and a null reference in `C#` are internally represented as the number zero, and so any attempt to dereference it into its corresponding memory storage causes the operating system to produce an error. The .NET runtime then detects this error and turns it into the null dereference exception.
That's why dereferencing both a null pointer and a null reference produces the same exception. 
What about the second point? Dereferencing *any* invalid pointer that falls in the lowest page of virtual memory causes the same operating system error, and thereby the same exception.
Why does this make sense?  Well, suppose we have a struct containing two ints, and an unmanaged pointer equal to null. If we attempt to dereference the second int in the struct, the `CLR` will not attempt to access the storage at location zero; it will access the storage at location four. But logically this is a null dereference because we are getting to that address *via* the null.
If you are working with unsafe code and you get a null dereference exception, just be aware that the offending pointer need not be null. It can be any location in the lowest page, and this exception will be produced.
