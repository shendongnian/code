    public override void WriteString(string text)
    {
        // The start index of the next substring containing only non-entitized characters.
        int start = 0;
        // The index of the current character being checked.
        for (int curr = 0; curr < text.Length; ++curr)
        {
            // Check whether the current character should be entitized.
            char chr = text[curr];
            if (chr == '\r' || chr == '\n' || chr == '\t')
            {
                // Write the previous substring of non-entitized characters.
                if (start < curr)
                    base.WriteString(text.Substring(start, curr - start));
                // Write current character, entitized.
                base.WriteCharEntity(chr);
                // Next substring of non-entitized characters tentatively starts
                // immediately beyond current character.
                start = curr + 1;
            }
        }
        // Write the trailing substring of non-entitized characters.
        if (start < text.Length)
            base.WriteString(text.Substring(start, text.Length - start));
    }
