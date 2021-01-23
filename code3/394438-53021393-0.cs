    // Explicitly specify the return value to the Base type
    var nodes = xmlDoc.Root.Elements().Select<XElement, Base>((e, index) => {
        string type = (e.Attribute("type") != null)?e.Attribute("type").Value:null;
        if(type != null) {
            if(type.Equals("Der1")) {
                // If you have something like an order property, you can assign it to index
                return new Der1() { Attr1 =  e.Attribute("attr1").Value };
            }
            else if(type.Equals("Der2")) {
                return new Der2() { Attr2 =  e.Attribute("attr2").Value };
            }
            else {
                return null;
            }
        } else {
            // You can also throw an Exception and handle it.
            return null;
        }
    }).ToList();
