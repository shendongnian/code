c#
public class Person
{
    public string FullName { get; set; }
    //I suggest the PhoneNumber should be a string type.
    public string PhoneNumber { get; set; }
    public int CarQTY { get; set; }
    public Person() { }
    public Person(string fullName, string phoneNumber, int carQTY) : this()
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        CarQTY = carQTY;
    }
    public static Person Parse(string fullName, string phoneNumber, int carQTy)
    {
        if (!TryParse(fullName, phoneNumber, carQTy, out Person person))
            throw new ArgumentException("Incorrect Arguments");
        return new Person(fullName, phoneNumber, carQTy);
    }
    public static bool TryParse(string fullName, string phoneNumber, int carQTy, out Person person)
    {
        person = null;
        if (!string.IsNullOrEmpty(fullName) &&
            !string.IsNullOrEmpty(phoneNumber) &&
            carQTy > 0)
        {
            person = new Person(fullName, phoneNumber, carQTy);
        }
        return person == null ? false : true;
    }
    public override string ToString()
    {
        return $"{FullName}, {PhoneNumber}, {CarQTY}";
    }
}
Now, you have two new static functions (`Parse`, `TryParse`) the caller can use to create  a valid objects. So you can do:
c#
public class SomeClass
{
    private void CreatePerson()
    {
        if(!Person.TryParse(fullName, phoneNumber, carQty, out Person person))
        {
            MessageBox.Show("Invalide Args");
            return;
        }
                
        //You have a valid person object...
    }
}
Or
c#
public class SomeClass
{
    private void CreatePerson()
    {
        Person person;
        try
        {
            person = Person.Parse(fullName, phoneNumber, carQty);
            //You have a valid person object...
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
