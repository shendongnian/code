    void RewriteMethods(IEnumerable<JClass> classes)
    {
        var codes = GetCodes(classes);
        var candidates = GetCandidates(codes);
        foreach (var candidate in candidates)
        {
            var code = candidate.Item1;
            var ex = candidate.Item2;
            var instructionsToRemove = code.Instructions
                                           .Skip(ex.HandlerStart)
                                           .TakeWhile(i => i.OpCode != Return)
                                           .Where(i => i.OpCode == AThrow);
            code.RemoveAll(instructionsToRemove);
        }
    }
