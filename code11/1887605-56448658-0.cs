    public static Test SingleAgeOrMaxThreshold(this IEnumerable<Test> items, int age)
    {
        Test max = null;
        foreach (Test t in items)
        {
            if (t.Age == age)
                return t;
            if (max == null || t.Threshold > max.Threshold)
                max = t;
        }
        return max;
    }
