    /// <summary>
    /// <para>Compares two floating point values if they are similar.</para>
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static bool Approximately(float a, float b)
    {
       return (double) Mathf.Abs(b - a) < (double) Mathf.Max(1E-06f * Mathf.Max(Mathf.Abs(a),
           Mathf.Abs(b)), Mathf.Epsilon * 8.0f);
    }
