public class Appointment  
{  
    ...
    private User user;  
    public string UserFullName => $"{user.FirstName} {user.LastName}";  
    ...  
}
    builder.HasOne<User>("user")
        .WithMany()
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Restrict);
And don't forget to `.Include("user")` when building your query.
Also note that this user is now being tracked by your DbContext and if you modify it it's changes will be saved to the DB on a later `SaveChanges` call.
