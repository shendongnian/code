    var i = 0;
    while (i < Sampleclass.Count) {
      if (Sampleclass[i].Address.Contains("")) {
        Sampleclass.RemoveAt(i);
      } else {
        i++;
      }
    }
