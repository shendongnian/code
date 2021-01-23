    int index = -1;
    int bcount = 0;
    for (int i = 0; i < aqtn.Length; ++ i)
    {
        if (aqtn[i] == '[')
            ++bcount;
        else if (aqtn[i] == ']')
            --bcount;
        else if (bcount == 0 && aqtn[i] == ',')
        {
            index = i;
            break;
        }
    }
    string typeName = aqtn.Substring(0, index);
    var assemblyName = new System.Reflection.AssemblyName(aqtn.Substring(index + 1));
