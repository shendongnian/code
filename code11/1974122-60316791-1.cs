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
