    private TextRange LatestSymbol
    {
        get
        {
            if (_previousCaretPosition != null)
            {    
                return new TextRange(
                           InputString.CaretPosition.GetPositionAtOffset(-1), 
                           InputString.CaretPosition
                        );
                    }
                return null;
            }
        }
    }
