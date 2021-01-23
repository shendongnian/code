    procedure AddFieldDocVarsToPlaceHolders(const Doc: WordDocument);
    var
      i: Integer;
      OleTrue: OleVariant;
      OleFalse: OleVariant;
      OleEmpty: OleVariant;
      FindText: OleVariant;
      Replace: OleVariant;
      FieldType: OleVariant;
      NewField: Field;
    begin
      OleTrue := True;
      OleFalse := False;
      OleEmpty := '';
      Replace := wdReplaceOne;
      FieldType := wdFieldDocVariable;
    
      // Skip the titles.
      for i := 1 to PlaceHoldersEdit.Strings.Count do begin
        FindText := Format('%s', [PlaceHoldersEdit.Keys[i]]);
    
        FWord.Selection.SetRange(0, 0); // Back to the beginning of the document.
        while FWord.Selection.Find.ExecuteOld({FindText}FindText, {MatchCase}EmptyParam, {MatchWholeWord}EmptyParam,
          {MatchWildcards}EmptyParam, {MatchSoundsLike}EmptyParam, {MatchAllWordForms}EmptyParam, {Forward}OleTrue,
          {Wrap}OleFalse, {Format}EmptyParam, {ReplaceWith}OleEmpty, {Replace}Replace )
        do begin
          NewField := FWord.Selection.Fields.Add({Range}FWord.Selection.Range, {Type_}FieldType, {Text}FindText, {PreserveFormatting}OleTrue);
          NewField.ShowCodes := False; // Make sure document variable name is hidden
          // Select this field and set selection to the end of its definition, making
          // doubly sure we won't find its name and replace it again.
          NewField.Select;  
          FWord.Selection.SetRange(FWord.Selection.End_, FWord.Selection.End_);
        end;
    
      end;
    end;
