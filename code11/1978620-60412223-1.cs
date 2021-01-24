`
arrError.Select(r1 => new 
{ 
	Name = r1.name, 
	Age = r1.age,
	subject = r1.subject != null ? string.Join("_", r1.subject) : null 
});
`
for test i used : 
`
// class like your structure
public class TestClass
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string[] Subject { get; set; }
}
// initializing the list
List<TestClass> testClasses = new List<TestClass>
{
	new TestClass{Name = "user1", Age=25, Subject = null},
	new TestClass{Name = "user132", Age=26, Subject = null},
	new TestClass{Name = "user2", Age=30, Subject = new string[]{"S1","S2","S3","S4"}},
	new TestClass{Name = "user3", Age=28, Subject = new string[]{"S1","S3"}},
};
// simulating your demand
var result = testClasses.Select(r1 => new 
{ 
	Name = r1.Name, 
	Age = r1.Age,
	Subject = r1.Subject != null ? string.Join("_", r1.Subject) : null 
});
