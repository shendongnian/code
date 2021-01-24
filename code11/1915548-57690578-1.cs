interface IPetHouse<out T> where T : IPet
{
	T Pet { get; }
};
class CatHouse : IPetHouse<Cat>
{
	public Cat Pet => new Cat();
}
class DogHouse : IPetHouse<Dog>
{
	public Dog Pet => new Dog();
}
// 'out' keyword gives possibility to treat CatHouse and DogHouse as IPetHouse<IPet> since IPet is less derived type
var petHouses = new IPetHouse<IPet>[] {
	new CatHouse(),	
	new DogHouse()
};
// Types are preserved, which you can check easily 
petHouses.Select(ph => ph.Pet.GetType().Name); //outputs: Cat and Dog 
On the other hand, to mark interface as **contravariant** (i.e. to enable to use a more generic (less derived) type than originally specified), you need to use `in` keyword next to its generic type parameter(s), as shown in the example:
interface IPetHouse<in T> where T : IPet
{
	void AddPet(T pet);
};
class PetHouse : IPetHouse<IPet>
{
	public void AddPet(IPet pet)
	{
	}
}
class CatHouse : IPetHouse<Cat>
{
	public void AddPet(Cat pet)
	{
	}
}
// 'in' keyword gives possibility to treat PetHouse as a CatHouse, since Cat is more derived type
IPetHouse<IPet> petHouse = new PetHouse();
IPetHouse<Cat> catHouse = petHouse;
petHouse.AddPet(new Cat()); // requires Cat to be passed
More info can be found on the official MSDN [page][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance
