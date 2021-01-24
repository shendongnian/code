        private Word.ContentControl IsSelectionInCC(Word.Range sel)
        {
            Word.Range rng = sel.Range;
            Word.Document doc = (Word.Document) rng.Parent;
            rng.Start = doc.Content.Start;
            int nrCC = rng.ContentControls.Count;
            Word.ContentControl cc = null;
            bool InCC = false;
            rng.Start = doc.Content.Start;
            if (nrCC > 0)
            {
                if (sel.InRange(doc.ContentControls[nrCC].Range))
                {
                    InCC = true; //Debug.Print ("Sel in cc")
                    cc = doc.ContentControls[nrCC];
                }
                else
                {
                    sel.MoveEnd(Word.WdUnits.wdCharacter, 1);
                    if (sel.Text == null)
                    {
                        //Debug.Print ("Sel at end of cc")
                        InCC = true;
                        cc = doc.ContentControls[nrCC];
                    }
                }
            }
            return cc;
        }
