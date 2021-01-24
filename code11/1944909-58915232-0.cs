//Marker
public interface IProjectOwner
{
    
}
public class Project
{
    public int Id { get; set; }
    // A Project can either have a Member as owner ...
    public int? MemberId { get; private set; }
    public Member ProjectOwner { get; private set; }
    // ... or an ExternalResourcePerson
    public int? ExternalResourcePersonId { get; private set; }
    public ExternalResourcePerson ExternalProjectOwner { get; private set; }
    public void SetProjectOwner(IProjectOwner projectOwner)
    {    
        //Add some validation for this. Like checking if the project owner is set.
        if(projectOwner == null)
            throw new Exception("Project owner cannot be null.");
        if(projectOwner is Member )
        {
            ProjectOwner = projectOwner;
            MemberId = projectOwner.Id;
        }
        if(projectOwner is ExternalResourcePerson)
        {
            ExternalProjectOwner = projectOwner;
            ExternalResourcePersonId = projectOwner.Id;
        }
    }
}
public class Member : IProjectOwner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Zip { get; set; }
    public List<Project> Projects { get; set; }
}
public class ExternalResourcePerson : IProjectOwner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Organisation { get; set; }
    public string Expertise { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }
    public List<ExternalResourcePersonEngagement> Engagements { get; set; }
}
public class ExternalResourcePersonEngagement
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int ExternalResourcePersonId { get; set; }
    public ExternalResourcePerson Person { get; set; }
}
You can also add some method that will retrieve this person.
