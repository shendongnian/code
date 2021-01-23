    object docStart = worddocpromo.Content.End - 1;
    object docEnd = worddocpromo.Content.End;
    object start = SubDoc.Content.Start;
    object end = SubDoc.Content.End;
    SubDoc.Range(ref start, ref end).Copy();
    Microsoft.Office.Interop.Word.Range rng = worddocpromo.Range(ref docStart, ref docEnd);
    rng.Paste();
