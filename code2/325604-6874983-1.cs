    public interface IPersonView : IView {
       String PersonName { get; set; }
       DateTime? DOB { get; set; }
    
       event EventHandler SavePerson;
    }
