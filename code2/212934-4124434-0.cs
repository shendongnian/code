    StringBuilder address = new StringBuilder();
    address.AppendLine(name);
    address.AppendLine(strasse);
    address.Append(plz.ToString()); // This may not be neccessary depending on the type of plz, StringBuilder has overloads that will convert base types to string for you
    address.Append(" ");
    address.Append(ort);
    if (!string.IsNullOrEmpty(telefon))
    {
         address.AppendLine();
         address.Append("Telefon:: ");
         address.Append(telefon);
    }
    if (!string.IsNullOfEmpty(natel))
    {
         address.AppendLine();
         address.Append("Natel: ");
         address.Append(natel);
    }
    if (!string.IsNullOrEmpty(mail))
    {
         address.AppendLine();
         address.Append(E-Mail: ");
         address.Append(mail);
    }
    return sb.ToString();
