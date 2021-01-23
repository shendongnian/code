    public static System.Data.DataTable GetContactList(string[] _county){
        var ranges = new Dictionary<string, object>
        {
          {"ContactPerson.1.County", _county}
        };
        var dt = Microsoft.Dynamics.Framework.Reports.AxQuery.ExecuteQuery("Select   ContactPerson.1.Name, ContactPerson.1.County from Contactsquery", ranges);
        return dt;
    }
