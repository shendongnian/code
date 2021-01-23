public class EditProductUserControl : UserControl
{
    public EditProductUserControl(EditProductPresenter presenter)
    {
        // initialize databindings based on properties of the presenter
    }
}
public class EditProductPresenter
{
    // Autofac will do some magic when it sees this injected anywhere
    public delegate EditProductPresenter Factory(int productId);
    public EditProductPresenter(
        ISession session, // The NHibernate session reference
        IEventBroker eventBroker,
        int productId)    // An optional product identifier
    {
        // do stuff....
    }
    public void Save()
    {
        // do stuff...
        this.eventBroker.Publish("ProductSaved", new EventArgs(this.product));
    }
}
public class ListProductsPresenter
{
    private IEventBroker eventBroker;
    private EditProductsPresenter.Factory factory;
    private IWindowWorkspace workspace;
    public ListProductsPresenter(
        IEventBroker eventBroker,
        EditProductsPresenter.Factory factory,
        IWindowWorkspace workspace)
    {
       this.eventBroker = eventBroker;
       this.factory = factory;
       this.workspace = workspace;
       this.eventBroker.Subscribe("ProductSaved", this.WhenProductSaved);
    }
    public void WhenDataGridRowDoubleClicked(int productId)
    {
       var editPresenter = this.factory(productId);
       var editControl = new EditProductUserControl(editPresenter);
       this.workspace.Open(editControl);
    }
    public void WhenProductSaved(object sender, EventArgs e)
    {
       // refresh the data grid, etc.
    }
}
