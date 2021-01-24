    public void TestRangeInToc()
    {
        Word.Document doc =Globals.ThisAddIn.Application.ActiveDocument;
        bool HasToc = false;
        
        if(doc.TablesOfContents.Count > 0)
        {
            HasToc = true;
        }
        
        foreach(Word.Paragraph para In doc.Paragraphs)
        {
            if(HasToc)
            {
                if(IsRangeInTOC(para.Range, doc))
                {
                   Debug.Print("in range");
                   //skip this one
                }
            }
        }
    }
    
    public bool IsRangeInTOC(Word.Range rng, Word.Document doc)
    {
        Word.TableOfContents toc         
        foreach(toc in doc.TablesOfContents)
        {
            if(rng.InRange(toc.Range))
            {
                return true;
                break;
            }
        }
            
    }
