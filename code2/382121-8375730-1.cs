    using (WordprocessingDocument doc = WordprocessingDocument.Open("c:\\temp\\checkbox.docx", true))
    {
      foreach (CheckBox cb in doc.MainDocumentPart.Document.Body.Descendants<CheckBox>())
      {
        Console.Out.WriteLine(cb.LocalName);
        FormFieldName cbName = cb.Parent.ChildElements.First<FormFieldName>();
        Console.Out.WriteLine(cbName.Val);
        DefaultCheckBoxFormFieldState defaultState = cb.GetFirstChild<DefaultCheckBoxFormFieldState>();
        Checked state = cb.GetFirstChild<Checked>();
        Console.Out.WriteLine(defaultState.Val.ToString());
          
        if (state.Val == null) // In case checkbox is checked the val attribute is null
        {
          Console.Out.WriteLine("CHECKED");
        }
        else
        {
          Console.Out.WriteLine(state.Val.ToString());
        }
      }
    }
