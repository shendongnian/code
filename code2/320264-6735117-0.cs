    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    foreach(var hash in newListing.Take(newListing.Count - 1)){
       sb.Append(hash.ToString());
    }
    sb.Append("\nTotal Found");
    string Conbinestr = sb.ToString();
