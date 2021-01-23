    int i = 0; // insert index
    int j = 0; // new items index
    while (j < newTweets.Count)
    {
        while (i < itemsSource.Count &&
            itemsSource[i].CreatedAt >= newTweets[j].CreatedAt)
        {
            i++;
        }
        itemsSource.Insert(i, newTweets[j]);
        j++;
    }
