    public static void CallAllAndCatch(this Delegate self, params object[] args)
        where T : EventArgs
    {
        if (self == null)
            return;
        foreach (Delegate i in self.GetInvocationList()) {
            try { i.DynamicInvoke(args); }
            catch (MemberAccessException) { throw; } // A type of something in args isn't compatible with the delegate signature.
            catch (TargetException) { throw; } // The delegate itself is invalid.
            catch { } // Catch everything else.
        }
    }
