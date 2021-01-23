    XElement xe = XElement.Load(yourXml);
    
    Control[] controls = new[] { Card01Desc, Card02Desc, Card03Desc };
    var cards = xe.Desendents("card");
    
    for (var i = 0; i < cards.Count(); i++)
    {
        ((YourControlType)controls[i]).Text = cards.Where(e => e.Attribute("id").Value == i).Desendents("description").First().Value;
    }
