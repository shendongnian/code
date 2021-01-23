    var map = new Dictionary<bool, FontStyle>
              {
                 { isBold, FontStyle.Bold },
                 { isItalic, FontStyle.Italic },
                 { isStrikeout, FontStyle.Strikeout },
                 { isUnderline, FontStyle.Underline }
              };
    
    var style = map.Where(kvp => kvp.Key)
                   .Aggregate(FontStyle.Regular, (styleSoFar, next) 
                                                => styleSoFar | next.Value);
