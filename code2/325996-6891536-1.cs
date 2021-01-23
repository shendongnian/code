    public class MyViewModel
    {
       public MyViewModelClass()
       {
          Gender = "M";
       }
       public IEnumerable<string> Genders { get { return new string[] { "M", "F" } };
       public string Gender { get; set; }
    }
