    public static class FlagsHelper
    {
        // This is not exactly perfect, as it allows you to call GetFlags on any
        // struct type, which will throw an exception at runtime if the type isn't
        // an enum.
        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum flags)
            where TEnum : struct
        {
            // Unfortunately this boxing/unboxing is the easiest way
            // to do this due to C#'s lack of a where T : enum constraint
            // (there are ways around this, but they involve some
            // frustrating code).
            int flagsValue = (int)(object)flags;
            
            foreach (int flag in Enum.GetValues(typeof(TEnum)))
            {
                if ((flagsValue & flag) == flag)
                {
                    // Once again: an unfortunate boxing/unboxing
                    // due to the lack of a where T : enum constraint.
                    yield return (TEnum)(object)flag;
                }
            }
        }
    }
