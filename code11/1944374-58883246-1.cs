c#
    public void AddEmailSetting(EmailSetting emailSetting)
    {
      try
      {
          entities.EmailSetting.Add(emailSetting);
          entities.SaveChanges();
      }
      catch (Exception ex)
      {
        MiscClasses.Logging.Log(MethodBase.GetCurrentMethod().Name, "An error occurred attempting to GetDefaultEmailSetting.", ex);
        throw;
      }
    }
    public void UpdateEmailSetting(EmailSetting emailSetting)
    {
      try
      {
          entities.EmailSetting.Update(emailSetting);
          entities.SaveChanges();
      }
      catch (Exception ex)
      {
        MiscClasses.Logging.Log(MethodBase.GetCurrentMethod().Name, "An error occurred attempting to GetDefaultEmailSetting.", ex);
        throw;
      }
    }
Also, injecting the entity into the object that it tracks seems weird?  Maybe that's a pattern I'm not familiar with. 
The way I would have gone about it would be to either have a separate class that manages the entities, or just inject the dbContext and perform the CRUD operations on the entity I needed from the context.
For example, lets say you had a controller (and the dbContext was injected into your Controller) that received the object you wanted to Add (follow the same pattern for update) you would do the following; 
c#
[Route("~/add")]
public IActionResult Add(EmailSetting emailSetting)
{
    // Whatever null checks or validation you wanted to do here.
    _dbContext.EmailSetting.Add(emailSetting);
    _dbContext.SaveChanges();     
   //return or redirect to whatever view/method after adding.
} 
You would follow the same pattern for Update, changing the route and the method name, and then for the `_dbContext.EmailSetting.Update(object);`. 
