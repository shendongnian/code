    const string l = ",(";
    const string r = "),";
    const char c = ',';
    const char a = '"';
    var line = "\"One,Two,(OneB,TwoB),Five\"";
    line = string.Join(string.Empty, line.Split(a)); //Strip "
    var splitL = line.Split(l); //,(
    var partsList = new List<string>();
    foreach (var value in splitL)
    {
        if (value.Contains(r))//),
        {
            //inside of parentheses, so we keep the values before the ),
            var splitR = value.Split(r);//),
            //I don't like literal indexes, but we know we have at least one element because we have a value.
            partsList.Add(splitR[0]);
            //Everything else is after the closing parenthesis for this group, and before the parenthesis after that
            //so we'll parse it all into different values.
            //The literal index is safe here because split always returns two values if any value is found.
            partsList.AddRange(splitR[1].Split(c));//,
        }
        else
        {
            //before the parentheses, so these are all different values
            partsList.AddRange(value.Split(c));//,
        }
    }
    var lineparts = partsList.ToArray();
