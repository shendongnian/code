    var predicates = new List<Func<XElement, bool>>();
    for (int i = 1; i < chkBx.Count(); i++)
    {
        if (chkBx[i].Checked)
        {
            var match = chkBx[i].Text;
            predicates.Add(el => (string)el.Parent.Element("Diameter") == match)
        }
    }
    selectedElements = selectedElements.Where(el => predicates.Any(p => p(el)));
