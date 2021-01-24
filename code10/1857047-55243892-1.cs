           SymbolNo = text,
           IsDuplicate = textsEqualToThisKey.Skip(1).Any(), // more efficient than Count()
       })
    // (C) Keep only those SymbolNos that have duplicates
    .Where(group => group.IsDuplicate)
    .Select(group => group.SymbolNo
    // (D) From the remaining duplicates make a string
    // TODO
