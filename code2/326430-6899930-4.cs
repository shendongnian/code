    int parsedInt;
    var sortedElements =
        from element in elements
        let hiddenAttribute = element.Attribute("IsHidden")
        let positionAttribute = element.Attribute("Position")
        // add other attributes here
        select new
            {
                IsHidden = hiddenAttribute == null || hiddenAttribute.Value != "false",
                Position = positionAttribute == null || !int.TryParse(positionAttribute.Value, out parsedInt)
                    ? default(int?)
                    : parsedInt,
                // add other parsed attributes here
            };
