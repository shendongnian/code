    public IEnumerable<Spell> GetSpellsForClass(string classname) {
        if (AccessSpellClass.TryGetValue(classname, out var accessExpr)) {
            Expression<Func<string,bool>> testExpr = x => !String.IsNullOrEmpty(x);
            var newTestBody = testExpr.Body.Replace(testExpr.Parameters[0], accessExpr.Body);
            var newTestExpr = Expression.Lambda<Func<Spell,bool>>(newTestBody, accessExpr.Parameters[0]);
    
            return _context.Spells.Where(newTestExpr);
        }
        else
            return Enumerable.Empty<Spell>();
    }
