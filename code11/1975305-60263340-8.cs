     using System.Linq;
      ...
      string[] item_list = {
        "PN=12345678",
        "PN=1234-5678-0001",
        "PN=1234-4321-0001;LOT=xyz" 
      };
      // let's query item_list:
      //   for each item within item_list 
      //   we create a Label
      //   all the labels we materialize in a List 
      List<Label> labels = item_list
        .Select((item, index) => new Label() {
          Text     = FormatMe(item),
          Location = new Point(10, 50 + 40 * index), //TODO: put the right locations here
          AutoSize = true,
          Parent   = this, // Instead of this.Controls.Add(...);
         })
        .ToList();
