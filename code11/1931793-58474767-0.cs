C#
List<Type> Types = Assembly.GetExecutingAssembly().GetTypes()
	.Where(t => t.Namespace == "Tester.Tests").ToList();
//Creates a list of all classes in "Tester.Tests" namespace
foreach (Type item in Types)
{
	TestsList.Add(Activator.CreateInstance(item));
}
//Creates an instance (object) of each class in Types
TestNames = new ObservableCollection<string>(); //Initialized before
//Note that all classes in "Tester.Test" implemented "ITest" interface
foreach (ITest item in TestsList)
{
	ُTestNames.Add(item.Name);
}
