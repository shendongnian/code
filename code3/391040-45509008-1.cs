    var name = from r in objClientList
               where r.ClientCode == Convert.ToInt32(drpClientsInternal.Items[i].Value)
               select r.IsInternalClient;
    foreach (bool c in name)
    {
        if (c)
        {
            ClientNameInternal = ClientNameInternal + drpClientsInternal.Items[i].Text +", ";
            drpClientsInternal.Items[i].Selected = true;
        }
    }
