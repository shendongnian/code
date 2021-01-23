    var result = allItems.Select(
        item=>
        item.Prop1==item.Prop2
           ? item.Prop1
           : String.Format("{0}-{1}",
              item.Prop1, item.Prop2)
    );
