    public class Appointment
    {
       public IEnumerable<SelectListItem> Clinic {get; set;}
     //You should add this for every dropdown menu you intend to put in the list.
     //I am guessing you already have a model like this as this was not in the question
    }
    public class Clinic
    {
      public int ClinicId {get; set;}
      public string ClinicName {get; set;}
    }
