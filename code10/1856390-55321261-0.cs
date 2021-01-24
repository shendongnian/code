    Gtk.TreeIter _i;
    Gtk.TreeModel _m;
    if (myNodeView.Selection.CountSelectedRows () > 0) {
      myNodeView.Selection.GetSelected (out _m, out _i);
      if (_m != null && _i != null) {
        currentSongName.text = _m.GetValue (_i, 0); // assuming your song name is in column 0 of the NodeView.
      }
    }
