    HashSet<string> matches = new HashSet<string>();
    // this next bit can probably be simplified, perhaps using LINQ;
    // left alone as it is orthogonal
    for (int i = 1; i < chkBx.Count(); i++)   
     {
            if (chkBx[i].Checked == true)
            {
                string element = "Diameter";
                matches .Add(chkBx[i].Text);
            }
        }
    var selectedElements = selectedElements.Where(el =>
          matches.Contains((string)el.Parent.Element(element)));
