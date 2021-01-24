    ,                 Match the character “,” literally
    (?=               Assert that the regex below can be matched, starting at this position (positive lookahead)
       (              Match the regular expression below and capture its match into backreference number 1
          [^']        Match any character that is NOT a “'”
             *        Between zero and unlimited times, as many times as possible, giving back as needed (greedy)
          '           Match the character “'” literally
          [^']        Match any character that is NOT a “'”
             *        Between zero and unlimited times, as many times as possible, giving back as needed (greedy)
          '           Match the character “'” literally
       )*             Between zero and unlimited times, as many times as possible, giving back as needed (greedy)
       [^']           Match any character that is NOT a “'”
          *           Between zero and unlimited times, as many times as possible, giving back as needed (greedy)
       $              Assert position at the end of the string (or before the line break at the end of the string, if any)
    )
