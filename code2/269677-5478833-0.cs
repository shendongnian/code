    public bool Validate(Crate crate)
    {
        return !crate.Sections
               .Any(a => crate.Sections
                         .Where(b => b.Value.PixelsWide != a.Value.PixelsWide).Any()
               );
    }
