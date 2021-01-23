    public static IEnumerable<T> Rotate<T>(IEnumerable<T> source, int count)
    {
        int i = 0;
        T[] temp = new T[count];
        foreach (var item in source)
        {
            if (i < count)
            {
                temp[i] = item;
            }
            else
            {
                yield return item;
            }
            i++;
        }
        foreach (var item in temp)
        {
            yield return item;
        }
    }
    [Test]
    public void TestRotate()
    {
        var list = new[] { 1, 2, 3, 4, 5 };
        var rotated = Rotate(list, 3);
        Assert.That(rotated, Is.EqualTo(new[] { 4, 5, 1, 2, 3 }));
    }
