    using System.Linq;
    
    var items = Types
      .Select (rec => ListItem
        {
          Text = Rec.Type;
          Value = Rec.ID.ToString();
        }
    LstChangeLogType.Items.AddRange(items);
