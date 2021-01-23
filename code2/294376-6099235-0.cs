    if (ParserHelpers.IsIdentifierStart(base.CurrentCharacter))
    {
      using (IDisposable disposable = base.Context.StartTemporaryBuffer())
      {
        base.Context.AcceptUntil((char c) => ParserHelpers.IsNewLine(c));
        modelTypeName = base.Context.ContentBuffer.ToString();
        base.Context.AcceptTemporaryBuffer();
      }
      base.Context.AcceptNewLine();
    }
