    bool b = False;
    foreach (int id in ids)
            {
                foreach (objectX item in x)
                {
                    if (item.id == id)
                    {
                        b = True;
                        break;
                    }
                }
            }
    if (!b)
    {
        idDiferentes.Add(id);
    }
