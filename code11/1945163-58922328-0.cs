            Word.Range rng = null;
            //Substitute a specific Range object if working with a Range, rather than a Selection
            Word.ContentControl cc = IsSelectionInCC(wdApp.Selection.Range);
    
            if ( cc != null)
            {
                rng = cc.Range;
                rng.HighlightColorIndex = Word.WdColorIndex.wdYellow;
            }
