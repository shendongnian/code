c#
// you can simplify your DomainModel removing the IAggregate plus adding generics
public abstract class Entity<T>
{
    public T Id { get; set; }
}
// this is an Aggregate Root
public class Person : Entity<int>
{
    public string Name { get; set; }
    public string Avatar { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
//this is an Aggregate Root
public class Post : Entity<int>
{
    private List<Comment> _comments = new List<Comment>();
    public string Title { get; set; }
    public string Content { get; set; }
    public Person Author { get; set; }
    public IReadOnlyList<Comment> Comments => _comments;
    public void Reply(Comment comment)
    {
        _comments.Add(comment);
    }
    public void Delete(Comment comment, int personId)
    {
        if (!AreSame(comment.Author, personId))
            throw new Exception("You cannot delete a comment that is not yours. blablabla");
        _comments.Add(comment);
    }
    private bool AreSame(Person author, int personId)
    {
        return author.Id == personId;
    }
    public override string ToString()
    {
        return Title;
    }
}
// this is a Value Object part of Post Aggregate
public struct Comment
{
    public DateTime Date;
    public string Text;
    public Person Author;
    public Comment(DateTime date, string text, Person author)
    {
        Date = date;
        Text = text;
        Author = author;
    }
    public override string ToString()
    {
        return $"{Date} - {Author}: {Text}";
    }
}
If the PostComment is part of Post Aggregate, it can't be an EntityBase, because each Aggragate should have only one root (Id). You're modeling a domain where a Post may have N Comments. You can consider the PostComment as a Value Object instead an Entity removing his Id.
You should pay attention about the names you are using. Try to sound more natural. It is called, ubiquitous language, the words everybody speak.
User is a description that just have a sense in system's context, in other words, you should have a User if you dealing with Security or Authentication contexts, in a Blog Context you have a Person acting as Author.
Increase readability using terms your users says. Reply may be more natural than AddComment.
c#
    public void Reply(Comment comment)
    {
        _comments.Add(comment);
    }
Increase readability adding names for your conditions:
 c#
    public void Delete(Comment comment, int personId)
    {
        if (!AreSame(comment.Author, personId))
            throw new Exception("You cannot delete a comment that is not yours. blablabla");
        _comments.Add(comment);
    }
    private bool AreSame(Person author, int personId)
    {
        return author.Id == personId;
    }
