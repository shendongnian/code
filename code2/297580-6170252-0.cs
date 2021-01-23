    void Main()
    {
    	 var foundAnimal = FindAnimal("Monkey"); //Not null
    }
    
    List<Animal> Animals = new List<Animal>(){ new Animal() { AnimalName = "Monkey" }};
    
    public Animal FindAnimal(string name)
    {
    	return Animals.Find((a) => String.Equals(a.AnimalName, name, StringComparison.CurrentCultureIgnoreCase));
    }	
    public class Animal
    {
    	public string AnimalName { get; set; }
    }
