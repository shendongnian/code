    public class OriginEntry {
        public string Name {get; set;}
    }
    public interface IOriginList : IList<OriginEntry> {
        ...
    }
    
    public class OriginList : Interfaces.IOriginList {
       ...
    }
    // Binding code
    IList<IOriginEntry> originList = new OriginList();
    cboOrigin.DataBindings.Add(new Binding("SelectedValue", originList, "Name"));
