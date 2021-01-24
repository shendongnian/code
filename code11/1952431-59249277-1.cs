    public class PersonDobVm
    {
        public int Id { get; set; }
    public DateTime Dob { get; set; }
    public void MapToModel(Person p)
       {
           p.Dob = Dob;
       }
    }
