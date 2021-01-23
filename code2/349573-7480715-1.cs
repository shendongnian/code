	var bl = new BusinessLogic();
	
	bl.DisplayMessage += MsgDisplay.DisplayMessage;
	bl.DisplayDialogBox += MsgDisplay.DisplayDialogBox;
	
	bl.SomeMethod();
