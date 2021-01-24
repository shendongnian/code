C#
public class DogCage {
    public bool IsClean {get; set;}
    public List<Dog> Dogs { get; }
    public DogCage(){
        Dogs = new List<Dog>();
    }
}
Then create one and add dogs like so:
C#
DogCage myCage = new DogCage();
myCage.Dogs.Add(new Dog(5, "MrDog", "German shepherd"));
