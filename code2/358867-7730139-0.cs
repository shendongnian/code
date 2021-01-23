    var bo = new CustomerBO();
    bo.Update(customer);
    try
    {
       Email.SendProfileChangedNotification();
    }
    catch(Exception ex)
    {
       ErrorSignal.FromCurrentContext().Raise(ex);
    }
    Response.Redirect(Constants.ProfilePage);
