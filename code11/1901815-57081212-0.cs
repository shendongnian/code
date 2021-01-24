Actions action = new Actions(wd.Driver);
wd.Click(startRow);
action.KeyDown(startRow, Keys.Shift).Perform(); // Safari still crashes here 
wd.Click(endRow);
action.KeyUp(Keys.Shift).Perform();
I still can't get Safari code to work. If I use the same code but remove the startRow parameter in the call to action.KeyDown, it doesn't crash, but it also doesn't behave as though the shift key is being held down. That is, it clicks and selects the startRow and when it clicks the endRow, the selection simply moves to endRow (nothing else is selected). 
