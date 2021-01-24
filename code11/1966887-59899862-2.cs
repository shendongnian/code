 C#
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
}
Then you can use it like below;
 C# 
return db.AUTHORs.Where(a => a.Aid == Aid).Include(a => a.BOOKs).FirstOrDefault();
P.S: I strongly recommend you to create a model class for the junction type.
**EDIT**
With Database first approach you have to basically create a model class for each table in the database. 
So don't change your `OnMOdalCreating` method. Add a new Class like below;
C#
[Table("BOOK_AUTHOR")]
public class BookAuthor
{
    public int ISBN { get; set; }
    public int AId { get; set; }
    public virtual Book Book { get; set; }
    public virtual Author Author { get; set; }
}
then you need to bind the properties to primary key properties via attributes or FLuent API. After that, you will be able to get an author with books like below
 C#
var authorWithBooks = context.Authors
    .Include(a => a.BookAuthors.Select(ba => ba.Book))
    .Where(...)
    .ToList();
