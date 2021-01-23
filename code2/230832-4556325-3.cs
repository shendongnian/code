    var ret1 = str.Split(' ');
    var ret2 = new List<string>();
    ret2.Add("");
    int index = 0;
    foreach (var item in ret1)
    {
        if (item.Length + 1 + ret2[index].Length <= allowedLength)
        {
            ret2[index] += ' ' + item;
            if (ret2[index].Length >= allowedLength)
            {
                ret2.Add("");
                index++;
            }
        }
        else
        {
            ret2.Add(item);
            index++;
        }
    }
    return ret2;
