    private TextRange LatestSymbol
    {
        get
        {
            var previous = InputString.CaretPosition.GetPositionAtOffset(-1);
            if (previous != null)
            {    
                 return new TextRange(
                          previous,
                          InputString.CaretPosition
                        );
                    }
                return null;
            }
        }
    }
