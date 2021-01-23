    @functions
    {
        static List<string> qa = new List<string>();
    }
    @helper traverseFirst(dynamic node)
    {
       var items = node.Children.Where("umbracoNaviHide != true");
       foreach (var item in items) {
         foreach(var subItem in item.Descendants()) {
            if(subItem.Id == Model.Id)
            {
               qa.Add();
               break;
            }
         }
         @traverseFirst(item)
       }
    }
