public class UserViewModel
{
    public UserEducationalDetails CollegeName { get; set; }
}
it doesn't mean that the CollegeName is taken from a `UserEducationalDetails` model, it means it *is* a UserEducationalDetails model. This is clearly not what you intend. What you want to do is to read off the properties when you construct the `UserViewModel`, something like this:
public class UserViewModel
{
    // Types reflect the types used in the models
    public string CollegeName { get; private set; }
    public string SchoolName { get; private set; }
    public string FullName {get; private set;}
    public string MarriedStatus { get; private set; }
    public UserViewModel(UserEducationalDetails ued, UserPersonalDetails upd)
    {
        // Copy the properties that are relevant to this object
        CollegeName = ued.CollegeName;
        SchoolName = ued.SchoolName;
        FullName = upd.FullName;
        MarriedStatus = upd.MarriedStatus;
    }
}
