    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        //var toRemove = entry.Behaviors.FirstOrDefault(b => b is EventToCommandBehavior);
        //if (toRemove != null)
        //{
        //    entry.Behaviors.Remove(toRemove);
        //}
        entry.Behaviors.Clear();
    }
