    bool found = false;
    for (int i = 0; i < names.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(names[i, 1]))
        {
            found = true;
            break;
        }
    }
