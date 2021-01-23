    select new
    {
        house = PrettyHouseNumber(p.subNumber, p.streetNumber),
        ...
    };
    string PrettyHouseNumber(string sub, string street) {
        if (!string.IsNullOrEmpty(sub)) {
            return sub + "/" + street;
        } else {
            return "" + street; // NULL will go to "", if it can even ever come up
        }
    }
