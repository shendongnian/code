    string newInput = string.Format("{0}{0}{0}{0}{0}{0}{0}{0}", input.Trim().ToLower());
    //string newInput = input.Trim().ToLower();
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    int[] _exclStart = new int[100];
    int[] _exclStop = new int[100];
    int _excl = 0;
    for (int f = newInput.IndexOf("<script", 0, StringComparison.Ordinal); f != -1; )
    {
        _exclStart[_excl] = f;
        f = newInput.IndexOf("</script", f + 8, StringComparison.Ordinal);
        if (f == -1)
        {
            _exclStop[_excl] = newInput.Length;
            break;
        }
        _exclStop[_excl] = f;
        f = newInput.IndexOf("<script", f + 8, StringComparison.Ordinal);
        ++_excl;
    }
    sw.Stop();
    Console.WriteLine(sw.Elapsed.TotalMilliseconds);
