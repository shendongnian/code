c#
// class
class MyClass
{
    // constructor
    public MyClass(object myParam)
    {
    }
}
// make a object
object param = new object();
// pass param
var Items = new ObservableCollection<MyClass>(){new MyClass(param)};
