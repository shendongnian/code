	// Configure the data trigger
	// Configure the TriggerCollection
	TriggerCollection triggers = Interaction.GetTriggers(fillBrush);
	var focussedTrigger = new EventTrigger("GotFocus");
	focussedTrigger.Actions.Add(
				new ControlStoryboardAction{Storyboard = sbFocussed});
	var unfocussedTrigger = new EventTrigger("LostFocus");
	unfocussedTrigger.Actions.Add(
				new ControlStoryboardAction { Storyboard = sbUnfocussed });
	triggers.Add(focussedTrigger);
	triggers.Add(unfocussedTrigger);
