new Car
{
  Cost = 5,
  Registered = DateTime.Now,
  Owner = new Owner 
  { 
    Firstname = "Brian", 
    Lastname = "Badonde" 
  },
}
I've used an upper case property name because Microsoft Guidelines recommend all properties start with an upper case character.
