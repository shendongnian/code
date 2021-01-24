    Word.Application ap = new Word.Application();
    Word.Document document = ap.Documents.Open(@"C:\Users\ermcnnj\Desktop\Doc1.docx");
    Word.Range rng = document.Content;
    Word.Find wdFind = rng.Find;
    wdFind.Text = "apple";
    bool found = wdFind.Execute();
    if (found)
    {
        rng.InsertAfter("\n");
        rng.MoveStart(Word.WdUnits.wdParagraph, 1);
        Word.InlineShape ils = rng.InlineShapes.AddPicture(@"C:\Test\avatar.jpg", false, true, rng);
     }
