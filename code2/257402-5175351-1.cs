    (list, item)=>
      new {
        Result = list.Result + [(item.Key, (list.Working+[item.Value]).Average())], 
        Working=list.Working[1::]+[item.Value]
      }
