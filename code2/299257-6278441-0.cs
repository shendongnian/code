    public void sentText(string _BkMk, string _text, bool _break, RunProperties _rProp)
    {  
         Text text = new Text(_text) { Space = SpaceProcessingModeValues.Preserve };
         
         Run run = new Run(new RunProperties(_rProp));          
         run.Append(text);                    
        
         Paragraph paragraph1 = new Paragraph();
         paragraph1.Append(run);
        
         foreach (BookmarkStart bookmarkStart in bookmarkMap.Values)
         {
             if (bookmarkStart.Name.Value == _BkMk)
             {
                 bookmarkStart.InsertBeforeSelf(paragraph1);
                 if (_break)
                 {
                     bookmarkStart.InsertBeforeSelf(paragraph1);
                     bookmarkStart.InsertBeforeSelf(new Paragraph());
                 }
             }
         }
    }
