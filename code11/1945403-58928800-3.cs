public class ViewmodelB {
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Work { get; set; }
    public string Address { get; set; }
    public ViewmodelB(ViewmodelA x){
      Name = x.Name;
      Surname = x.Surname;
      //maybe initialize other properties here
    }
}
