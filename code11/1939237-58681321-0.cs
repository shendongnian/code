public class Animal {
    public int Id { get; set; }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
    public string Prop3 { get; set; }
    
    public override bool Equals(object obj)
    {
      Animal animal = (Animal) obj;
      if (animal == null)
      {
        return false;
      }
      //Compare the values we care about except Id! 
      return this.Prop1 == animal.Prop1
        && this.Prop2 == animal.Prop2
        && this.Prop3 == animal.Prop3;
    }
}
Now you can see if any existing ```Animal``` object using Equals override:
foreach (var row in json["data"]["animals"])
{
   var newRow = new Animal
   {
       Prop1 = row["prop1"].ToString(),
       Prop2 = row["prop2"].ToString(),
       Prop3 = row["prop3"].ToString(),
   }
   
    var existedAnimal = db.Animals.SingleOrDefault(x => newRow.Equals(x));
    if(existedAnimal == null){
         db.Animals.Add(newRow);
         db.SaveChanges();
    }
    else{
       //You can throw some exception. 
   }
}
