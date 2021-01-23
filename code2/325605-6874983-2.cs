    public class PersonPresenter : Presenter<IPersonView> {
       private IPersonDb PersonDB { get; set; }
    
       public PersonPresenter(IPersonView view, IPersonDb personDB)
          : base(view) {
          if (personDB == null)
             throw new ArgumentNullException("personDB");
    
          PersonDB = personDB;
       }
    
       protected override void OnViewInitialize(object sender, EventArgs e) {
          base.OnViewInitialize(sender, e);
    
          View.PersonName = "Enter Name";
          View.DOB = null;
    
          View.SavePerson += View_SavePerson;
       }
    
       void View_SavePerson(object sender, EventArgs e) {
          PersonDB.SavePerson(View.PersonName, View.DOB);
       }
    }
