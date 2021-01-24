        Word.Document doc = wdApp.ActiveDocument;
        Word.Style sOld = null;
        Word.Style sCopy = null;
        Word.Find f = doc.Content.Find;
        //Select Normal text, otherwise Normal will take on character formatting of current selected text
        Word.Selection sel = wdApp.Selection;
        sel.Find.set_Style(Word.WdBuiltinStyle.wdStyleNormal);
        sel.Find.Execute("", Type.Missing,
          Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Word.WdFindWrap.wdFindStop,
          true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        foreach (Word.Style s in doc.Styles)
        {
            if ((s.InUse) && (s.Type == Word.WdStyleType.wdStyleTypeParagraph) && 
                (!s.NameLocal.Contains(" Copy")))
            {
                sOld = s;
                sCopy = doc.Styles.Add(sOld.NameLocal + " Copy", sOld.Type);
                sCopy.set_BaseStyle(sOld);
                f.set_Style(sOld);
                f.Replacement.set_Style(sCopy);
                f.Execute("", Type.Missing, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, true, Word.WdFindWrap.wdFindStop, 
                true, "", Word.WdReplace.wdReplaceAll, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
