     Application word = new Application();
            word.Visible = true;
            Document doc= 
            word.Documents.Open(@"PATH");
            Range rng;
            Range rngText;
            object strStart = "STRING";
            object strEnd= "STRING";
            
            rng = doc.Content;
            rngText = doc.Range(0, 0);
            if(rng.Find.Execute(ref strStart))
            {
                rngText.SetRange(rng.Start,rng.End);
                rng.SetRange(rng.End, doc.Range().End   );
                if(rng.Find.Execute(ref strEnd))
                {
                    rngText.SetRange(rngText.Start,rng.Start);
                    rngText.Select();
                    rngText.Font.Color = WdColor.wdColorAqua;
                }
            }
