public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    ...
    public virtual ICollection<ProjectTechnologyLink> ProjectTechnologyLink { get; set; } = new HashSet<ProjectTechnologyLink>();
}
> __NOTE:__ In the above `Project` class definition I have used an inline initializer for the `ProjectTechnologyLink` relationship, i find this style fits in well with _Attribute Notation_ as the default value is now also defined in close proximity with the Property, when initializers are only only defined in the constructor it is easy to forget to include an _init_ at all or it can be hard to find the init logic in code. Now a quick "Got To Definition" will reveal the default implementation as well as any database schema related attributes without having to lookup other resources.
public class Technology
{ 
    public Technology()
    {
        ProjectTechnologyLink = new HashSet<ProjectTechnologyLink>();
    }
    [Key]
    public int TechnologyId { get; set; }
    public string TechnologyName { get; set; }
    ...
    public virtual ICollection<ProjectTechnologyLink> ProjectTechnologyLink { get; set; }
 }
public class ProjectTechnologyLink 
{
    [Key, Column(Order = 0)]
    public int ProjectId { get; set; }
    [Key, Column(Order = 0)]
    public int TechnologyId { get; set; }
    ...
    [ForeignKey(nameof(ProjectId))]
    public virtual Project Project { get; set; }
    [ForeignKey(nameof(TechnologyId))]
    public virtual Technology Technology { get; set; }
}
__*virtual* Navigation Properties:__
In EF it is important to mark your navigation properties as _virtual_ members. This will allow EF to implement lazy loading and perform other optimised implementation of those properties when it generates a wrapper class that inherits from your entity class. Even if you do not intend to support _Lazy Loading_, there are other scenarios where EF will wrap your class, and either way your data definition classes should not be concerned or aware of  operational decision that can be made and changed at runtime depending on your context needs.
> __Conventions:__
The previous example demonstrates pure attribute notation. It is very possible to replace the default _Conventions_ with your own for defining primary and foreign keys. Meaning it is theoretically possible to not have any attributes or Fluent notation at all. I try to discourage a pure convention based approach because it makes it a bit harder to find the configuration in a large or distributed schema definition, which is also the same argument I use to discourage a pure Fluent API approach, attributes are the logical place  to document the expected usage of a table or field.
