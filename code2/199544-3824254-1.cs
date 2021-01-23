    string nextBit = "";
    var sb = new StringBuilder();
    foreach(Person person in list)
    {
        sb.Append(nextBit);
        sb.Append(", ");
        nextBit = String.Format("{0}:{1}", person.ID, person.Name);
    }
    sb.Remove(sb.Length - 3, 2);
    sb.Append(" and ");
    sb.Append(nextBit);
