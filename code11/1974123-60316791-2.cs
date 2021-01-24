csharp
public int GetSameWordCount(Sentence sentence)
{
    var count;
    foreach(var word in sentence.Words)
    {
         if(Words.Contains(word))
             count++;
    }
    return count;
}
**Note**
If the list of the words is sorted you can use below approach.
csharp
        var enumerator1 = set1.GetEnumerator();
        var enumerator2 = set2.GetEnumerator();
        var count = 0;
        if (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            while (true)
            {
                var value = enumerator1.Current.CompareTo(enumerator2.Current);
                if (value == 0)
                {
                    count++;
                    if (!enumerator1.MoveNext() || !enumerator2.MoveNext())
                        break;
                }
                else if (value < 0)
                {
                    if (!enumerator1.MoveNext())
                        break;
                }
                else
                {
                    if (!enumerator2.MoveNext())
                        break;
                }
            }
        }
