    public static class Vector3Extensio s
    {
        public static bool IsSameValue(this Vector3 a, Vector3 b)
        {
            return Mathf.Approximately(Vector3.Distance(a,b), 0f);
        }
    }
