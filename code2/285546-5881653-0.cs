// *** GLOBAL.ASAX
// This collection will contain all the updatepanels that need to be updated
private List&lt;IUpdatePanelClient&gt; _registeredClients = new List&lt;IUpdatePanelClient&gt;();
public static void RegisterClient(IUpdatePanelClient client)
{
    _registeredClients.Add(client);
}
public static void UnregisterClient(IUpdatePanelClient client)
{
    _registeredClients.Remove(client);
}
// Which client is triggering the update call ?
private IUpdatePanelClient _clientUpdating = null;
public static IUpdatePanelClient ClientUpdating
{ 
    get { return _clientUpdating ; } 
    set { _clientUpdating = value; Notify(); }
}
// Notify the clients
public static void Notify()
{
    foreach(IUpdatePanelClient client in _registeredClients)
    {
        client.Update();
    }
}
// *** IUPdatePanelClient.CS
interface IUpdatePanelClient // Interface to make the calls
{
    void Update();
}
// *** Your codepage
public class MyUpdatePanelPage : Page, IUpdatePanelClient // Inherit the interface
{
    public void Page_Load(Object sender, EventArgs e)
    {
        MyUpdatePanelPage.Global.RegisterClient(this);
    }
    public void Btn_Click(Object sender, EventArgs e)
    {
        MyUpdatePanelPage.Global.ClientUpdating = this;
    }
    
    public void Update()
    {
        this._updatePanel1.Update();
    }
}
