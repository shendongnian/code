	var style = new Style(typeof(Ellipse));
	var trigger = new DataTrigger();
	trigger.Binding = new Binding("Opacity") { ElementName = "ellipse1" };
	trigger.Value = 0.5;
	Storyboard sb = new Storyboard();
	//Add animation to sb, note the attached storyboard properties which are set with static methods:
	//Storyboard.SetTarget(...);
	//Storyboard.SetTargetProperty(...);
	//Storyboard.SetTargetName(...);
	trigger.EnterActions.Add(new BeginStoryboard() { Storyboard = sb });
	style.Triggers.Add(trigger);
