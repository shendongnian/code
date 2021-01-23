    bool IsCompilerGenerated(Type t) {
        if (t == null)
            return false;
        return t.IsDefined(typeof(CompilerGeneratedAttribute), false)
            || IsCompilerGenerated(t.DeclaringType);
    }
