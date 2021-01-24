     using System.Linq;
      ...
      string[] item_list = {
        "PN=12345678",
        "PN=1234-5678-0001",
        "PN=1234-4321-0001;LOT=xyz" 
      };
      List<Label> labels = item_list
        .Select((item, index) => new Label() {
          Text     = FormatMe(item),
          Location = new Point(10, 50 + 40 * index), //TODO: put the right locations here
          Parent   = this,
         })
        .ToList();
