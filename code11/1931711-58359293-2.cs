    for (int i = 0; i < nodes.Count; i++)
    {
        sb.Append(nodes[i].Value);
        if (i == nodes.Count - 1)
            break;
        sb.Append(i % 2 == 0 ? ", " : " / ");
    }
