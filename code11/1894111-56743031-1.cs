    public IEnumerable<Spell> GetSpellsForClass(string classname) {
        if (AccessSpellClass.TryGetValue(classname, out var accessFn)) {
            return _context.Spells.Where(x => !string.IsNullOrEmpty(accessFn(x)));
        }
        else
            return Enumerable.Empty<Spell>();
    }
