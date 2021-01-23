    void server_onUpdate(string newStatus) {
      if (!listView1.Dispatcher.CheckAccess()) {
        listView1.Dispatcher.Invoke(server_onUpdate, newStatus)
      } else {
        listView1.Items.Add(newStatus);
      }
    }
