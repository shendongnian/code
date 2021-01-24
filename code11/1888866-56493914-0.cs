    for (int i = 0; i < Rotate.names.Length; i++)
    {
        ...
        int j = i;
        buttons[i].onClick.AddListener(() => ButtonClicked(j));
    }
