      using System.Text.Json;
      [...]
      IList<JsTreeModel> nodes = new List<JsTreeModel>();
        
      foreach (var item in items)
      {
        nodes.Add(new JsTreeModel
        {
          id = item.Id.ToString(),
          parent = item.ParentId == null ? "#" : item.ParentId.ToString(),
          text = item.Name
        });
      }
      //Serialize to JSON string.
      ViewBag.Json = JsonSerializer.Serialize(nodes);
      return View();
