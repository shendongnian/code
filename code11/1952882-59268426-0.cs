    public interface IMenuItem
    {
        IWebElement Parent { get; }
    }
    public class MenuItem : IMenuItem
    {
        public IWebElement Parent => throw new NotImplementedException();
    }
    public class MenuItems
    {
        public T GetMenuItem<T>() where T : IMenuItem, new()
        {
            var menuItem = new T();
            return menuItem;
        }
    }
    public abstract class Page : IEnumerable<IComponent>
    {
        private Func<IMenuItem> _getMenuItems = new MenuItems().GetMenuItem<MenuItem>;
    }
