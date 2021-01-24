    var QuoteSymbol = Pattern.Literal("QuoteSymbol", '"');
    var NonQuoteSymbol = Pattern.Custom("QuoteSymbol", s => s.ReadUntil('"'));
    var String = Pattern.Conjunction("String", QuoteSymbol, NonQuoteSymbol, QuoteSymbol);
    
    var WhiteSpace = Pattern.Custom("WhiteSpace", s => s.ReadWhile(char.IsWhiteSpace));
    var PlusSymbol = Pattern.Literal("PlusSymbol", '+');
    var Document = Pattern.Repetition(
        Pattern.Conjunction(WhiteSpace, String, WhiteSpace, PlusSymbol)
    );
    
    var results = from TerminalSymbol symbol
                  in Document.Parse(input)
                  where symbol.Pattern == String
                  select symbol.Value;
