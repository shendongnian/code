    using System.Linq;
    bool removed = false;
    foreach ( var item in imageListView1.Items.ToList() )
      if ( item.FileName == filenameToFind )
      {
        imageListView1.Items.Remove(item);
        removed = true;
        break;  // with a break it will only remove the first found else all duplicates
      }
