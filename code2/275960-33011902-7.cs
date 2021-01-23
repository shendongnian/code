    [System.Web.Services.WebMethod]
    public static string GetPeoplePickerData()
    {
        try
        {
            return PeoplePicker.GetPeoplePickerData();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
