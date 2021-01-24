interface IBaseResult {
	string PropertyYouCareAbout1 { get; }
	bool PropertyYouCareAbout2 { get; }
	// ...
	int PropertyYouCareAboutN { get; }
}
class Base : IBaseResult {
}
class Derived : Base {
}
public void Main() {
    List<Task<IBaseResult>> taskList = new List<Task<IBaseResult>>();
    for ( var i = 1; i < 10; i++) {
        switch (i%2) {
            case 0:
                taskList.Add(GetDerivedAsync());
                break;
            default:
                taskList.Add(GetBaseAsync());
                break;
        }
    }
    Task.WhenAll(taskList);
	
	// Do somethign with results in taskList
}
