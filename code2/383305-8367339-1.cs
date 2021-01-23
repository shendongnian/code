    XElement xe = XElement.Load(yourXml);
    
    Control[] controls = new[] { Card01Desc, Card02Desc, Card03Desc };
    var cards = xe.Descendants("card");
    
    for (var i = 0; i < cards.Count(); i++)
    {
        ((YourControlType)controls[i]).Text = cards.Where(e => e.Attribute("id").Value == i).Descendants("description").First().Value;
    }
