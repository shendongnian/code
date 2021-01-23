    private void WatchTopItemChanged(ListView listView, Action callOnChanged) {
      var lastTopItem = listView.TopItem;
      listView.DrawItem += delegate {
        if (lastTopItem != listView.TopItem) {
          lastTopItem = listView.TopItem;
          callOnChanged();
        }
      };
    }
