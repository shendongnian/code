    IEnumerable<JCode> GetCodes(IEnumerable<JClass> classes)
    {
        return from @class in classes
               from method in @class.Methods
               let code = method.Code
               where code != null
               select code;
    }
    IEnumerable<Tuple<JCode, JException>> GetCandidates(IEnumerable<JCode> codes)
    {
        return from code in codes
               from ex in code.Exceptions
               where !code.Instructions
                          .Skip(ex.Start)
                          .Take(ex.End - ex.Start + 1)
                          .Any(i => i.OpCode == New && ...)
               select Tuple.Create(code, ex);
    }
