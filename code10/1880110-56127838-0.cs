    for (int i = 0; i < zeichen.Length; i++)
    {
        if (i > 0 && Char.IsNumber(zeichen[i]) && Char.IsNumber(zeichen[i - 1])) // if got a number, and had a number before
        {
            // Then dont Add to the list, instead add to the number/string
            liste[list.Count - 1] += zeichen[i];
            //liste.Add(zeichen[i].ToString() + zeichen[i + 1].ToString());
        }
        else
            liste.Add(zeichen[i].ToString());
    }
    // "(", "32", "+", "5", ")", "*", "20"
