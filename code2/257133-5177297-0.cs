                    object start = SubDoc.Content.Start;
                    object end = SubDoc.Content.End;
                    //Microsoft.Office.Interop.Word.Range rng = worddocpromo.Range(ref docStart, ref docEnd);
                    //object range = (object)rng;
                    SubDoc.Range(ref start, ref end).Copy();
                    Microsoft.Office.Interop.Word.Range rng = worddocpromo.Range(ref docStart, ref docEnd);
                    rng.Paste();
