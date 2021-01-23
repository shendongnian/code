    const string newLine = " <br /> ";
    StringBuilder address = new StringBuilder();
    address.Append(name);
    address.Append(newLine);
    address.Append(strasse);
    address.Append(newLine);
    address.Append(plz.ToString()); // This may not be neccessary depending on the type of plz, StringBuilder has overloads that will convert base types to string for you
    address.Append(" ");
    address.Append(ort);
    if (!string.IsNullOrEmpty(telefon))
    {
         address.Append(newLine);
         address.Append("Telefon:: ");
         address.Append(telefon);
    }
    if (!string.IsNullOfEmpty(natel))
    {
         address.Append(newLine);
         address.Append("Natel: ");
         address.Append(natel);
    }
    if (!string.IsNullOrEmpty(mail))
    {
         address.Append(newLine);
         address.Append("E-Mail: ");
         address.Append(mail);
    }
    return address.ToString();
