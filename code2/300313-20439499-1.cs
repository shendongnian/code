    public partial class frm_main : Form
    {
         private WlanClient client = new WlanClient();
         private void UpdateNetworks()
         {
             var networks = new List<Wlan.WlanAvailableNetwork>();
             foreach (WlanClient.WlanInterface iface in client.Interfaces)
             {
                 Wlan.WlanAvailableNetwork[] nets = iface.GetAvailableNetworkList(0);
                 foreach (Wlan.WlanAvailableNetwork net in nets)
                     networks.Add(net);
             }
             MessageBox.Show(networks.Count.ToString());
         }
    }
