    IEnumerable<JCode> GetCodes(IEnumerable<JClass> classes)
    {
        return from @class in classes
               from method in @class.Methods
               where method.Code != null
               select method.Code;
    }
    IEnumerable<Tuple<JCode, JException>> GetCandidates(IEnumerable<JCode> codes)
    {
        return from code in codes
               from ex in code.ExceptionTable
               where !code.Instructions
                          .Skip(ex.Start)
                          .Take(ex.End - ex.Start + 1)
                          .Any(i => i.OpCode == New && ...)
               select Tuple.Create(code, ex);
    }
