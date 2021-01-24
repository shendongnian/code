private bool DoingThing = false;
async void ChangeState(bool state)
{
 while(DoingThing)
    await Task.Delay(10);
 DoingThing = true;
 await OutsideApi.ChangeState(state);
 DoingThing = false;
}
async void DoStuff()
{
 while(DoingThing)
    await Task.Delay(10);
 DoingThing = true;
 await OutsideApi.DoStuff();
 DoingThing = false;
}
