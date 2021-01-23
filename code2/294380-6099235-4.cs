    [TestMethod]
    public void ParseModelKeyword_HandlesLongGenerics()
    {
      var document = "@model    Tuple<T,T,T,T,T>";
      var spans = ParseDocument(document);
      var expectedSpans = new Span[] {
        new TransitionSpan(new SourceLocation(0, 0, 0), "@") 
          { AcceptedCharacters = AcceptedCharacters.None },
        new MetaCodeSpan(new SourceLocation(1, 0, 1), "model ")
          { AcceptedCharacters = AcceptedCharacters.None },
        new ModelSpan(new SourceLocation(7, 0, 7), 
          "Tuple<T,T,T,T,T>", "Tuple<T,T,T,T,T>"),
      };
      CollectionAssert.AreEqual(expectedSpans, spans);
      Assert.IsNotNull(spans);
    }
