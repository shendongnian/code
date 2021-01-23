    int i = 0; // insert index
    int j = 0; // new items index
    while (j < newTweets.Count)
    {
        while (itemsSource[i].CreatedAt <= newTweets[j])
        {
            i++;
        }
        itemsSource.Insert(newTweets[j], i);
        j++;
    }
