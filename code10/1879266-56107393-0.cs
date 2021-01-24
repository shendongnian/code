    var storyboardQueue = new Queue<Storyboard>();
    storyboardQueue.Enqueue((Resources["sDeckToHandPositionOne"] as Storyboard));
    storyboardQueue.Enqueue((Resources["sResetPosition"] as Storyboard)); 
    storyboardQueue.Enqueue((Resources["sDeckToHandPositionTwo"] as Storyboard));
    storyboardQueue.Enqueue((Resources["sResetPosition"] as Storyboard));
    storyboardQueue.Enqueue((Resources["sDeckToHandPositionThree"] as Storyboard));
    storyboardQueue.Enqueue((Resources["sResetPosition"] as Storyboard));
    //... other storyboards
    PlayNextStoryBoard(storyboardQueue);
    private void PlayNextStoryBoard(Queue<Storyboard> storyboardQueue)
    {
        if (storyboardQueue.Count > 0)
        {
            var sb = storyboardQueue.Dequeue();
            sb.Completed += (o, e) =>
            {
                PlayNextStoryBoard(storyboardQueue);
            };
            sb.Begin();
        }
    }
