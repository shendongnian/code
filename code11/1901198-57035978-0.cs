c#
public class Book
{
    public Author Author {get; set;}
}
but because this isn't a normal class, instead it's a Model for Entity Framework we need to do this:
c#
public class Book
{
	public int BookId {get; set;}
    public string BookName {get; set;}
	public int AuthorId {get; set;}
	public virtual Author Author {get; set;}
}
Keeping your Author class like this
c#
public class Author
{
	public int AuthorId {get; set;}
	public int AuthorName {get; set;}
	public int AuthorAge {get; set;}
}
On the database this creates two tables:
Author Table:
|AuthorId|AuthorName|AuthorAge|
|--------|----------|---------|
|...     |...       |...      |
|--------|----------|---------|
Book Table:
|BookId|AuthorId|BookName|
|------|--------|--------|
|...   |...     |...     |
|------|--------|--------|
Where the `AuthorId` in the Book table is a foreign key onto the Author tables `AuthorId`
You can now access the Authors information of any book easily by doing `book.Author.AuthorName`.
P.S Please note that the tables are examples, the actual names of them and the names of the columns aren't what EF will generate in your database. They merely serve demonstration purposes
