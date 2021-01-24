     if (first) {
       // write the header with field names
        for (int i = 0; i < workitem.Fields.Count; i++) {
             Console.Write("{0}|", workitem.Fields[i].Name);
             Console.Write("\n");
             first = false;
            }
      }
