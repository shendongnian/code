            bool startComplete = false;
            for (int i = 0; i < Colors.Count; i++)
            {
                if (Colors[i].ResultConfidence > 60)
                {
                    // This item does not need to be changed
                    startComplete = true;
                }
                if (!startComplete)
                {
                    int twoItemsAway = i + 2;
                    if (twoItemsAway < Colors.Count)
                    {
                        if (Colors[twoItemsAway].Name == Colors[twoItemsAway - 1].Name && Colors[twoItemsAway].ResultConfidence > 60 && Colors[twoItemsAway - 1].ResultConfidence > 60)
                        {
                            // The next item, and the one after that both have the same value and 60+ confidence
                            for (int loopBack = i; loopBack >= 0; loopBack--)
                            {
                                Colors[loopBack].Name = Colors[twoItemsAway].Name;
                            }
                            startComplete = true;
                        }
                    }
                }
            }
            bool endComplete = false;
            for (int i = Colors.Count - 1; i >= 0; i--)
            {
                if (Colors[i].ResultConfidence > 60)
                {
                    // This item does not need to be changed
                    endComplete = true;
                }
                if (!endComplete)
                {
                    int twoItemsAway = i - 2;
                    if (twoItemsAway >= 0)
                    {
                        if (Colors[twoItemsAway].Name == Colors[twoItemsAway + 1].Name && Colors[twoItemsAway].ResultConfidence > 60 && Colors[twoItemsAway + 1].ResultConfidence > 60)
                        {
                            // The next item, and the one after that both have the same value and 60+ confidence
                            for (int loopForward = twoItemsAway; loopForward < Colors.Count; loopForward++)
                            {
                                Colors[loopForward].Name = Colors[twoItemsAway].Name;
                            }
                            endComplete = true;
                        }
                    }
                }
            }
            // Fill in the middle values.
            for (int i = 2; i < Colors.Count - 2; i++)
            {
                if (Colors[i].ResultConfidence < 60)
                {
                    int twoLeft = i - 2;
                    int oneLeft = i - 1;
                    int oneRight = i + 1;
                    int twoRight = i + 2;
                    if (Colors[twoLeft].Name == Colors[oneLeft].Name && Colors[oneLeft].Name == Colors[oneRight].Name && Colors[oneRight].Name == Colors[twoRight].Name
                        &&
                        Colors[twoLeft].ResultConfidence > 60 && Colors[oneLeft].ResultConfidence > 60 && Colors[oneRight].ResultConfidence > 60 && Colors[twoRight].ResultConfidence > 60)
                    {
                        Colors[i].Name = Colors[oneRight].Name;
                    }
                }
            }
