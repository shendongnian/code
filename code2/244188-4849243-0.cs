    for (int i = 0; i < Oo.Length; ++i)
    {
        var val = Oo[i];
        if (val.AddSeconds(30) < DateTime.Now)
        {
            Oo.RemoveAt(i);
            i--; // since we just removed an element
        }
    }
