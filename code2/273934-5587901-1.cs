    public interface MyInterface
    {
        IList<IMenuItem> MenuCollection { get; set }
    }
    public class MyClass : MyInterface
    {
        // WARNING: Does not count as implementing the interface -- with good reason
        public ObservableCollection<MenuItemBase> MenuCollection { get; set; }
    }
    var myClass = new MyClass();
    var classAsInterface = (MyInterface) myClass; // This is OK of course
    classAsInterface.MenuCollection = new List<MenuItemBase>(); // OOPS!!
