c#
public async Task Bounce()
{
  if(Bouncing) return;
  Bouncing = true;
  while(Ball.CurrentPosition.Y <= GameHeight)
  {
    Ball.CurrentPosition.Y++;
    StateHasChanged();
    await Task.Delay(500);
  }
// in case View has been resized, make sure Ball is not out of boundaries
  Ball.CurrentPosition.Y = GameHeight;
  StateHasChanged();
  Bouncing = false;
}
