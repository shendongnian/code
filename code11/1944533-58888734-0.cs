    public interface INames
    {
        string Name { get; set; }
        string SurName { get; set; }
    }
    // Implement INames in the classes you are using in ListControl
    public class Director : INames { }
    public class Actor : INames { }
    private void cmb_Format(object sender, ListControlConvertEventArgs e)
    {
        var item = (INames)e.ListItem;
        e.Value = $"{item.Name} {item.SurName}";
    }
