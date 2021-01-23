        SlideTransition slideTransition = new SlideTransition();
        ITransition transition = slideTransition.GetTransition(TargetImage);
        transition.Completed += delegate
        {
            transition.Stop();
        };
        transition.Begin();
