class Person
{
	public bool IsAdmin { get; set; }
	public string Name { get; set ; }
}
In the example above if the input comes with the attribute 'IsAdmin' with value true and your system treat all "Person's" with this attribute as a admin so you will have a security flaw. To overcome this you should create classes that only contains attributes and properties that you really need to read.
Fixed Ex:
class PersonModel
{
	public string Name { get; set ; }
	public Person ToPerson()
	{
		new Person { Name = Name };
	}
}
class Person
{
	public bool IsAdmin { get; set; }
	public string Name { get; set ; }
}
Now, using the PersonModel in the deserialization, the only properties that you really want will be loaded, the rest you be ignored by the serialization library. But, this will not make you free to security flaws. If the deserialization library have some kind of security issue you will be affected too.
Hope this help.
