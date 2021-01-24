    const double VERSION = 3.3;
    string withDots   = String.Format(new System.Globalization.CultureInfo("en-GB"), "{0:N}", VERSION));
    // "3.3"
    string withCommas = String.Format(new System.Globalization.CultureInfo("fr-FR"), "{0:N}", VERSION));
    // "3,3"
