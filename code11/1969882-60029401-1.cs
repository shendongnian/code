C#
while(p1.Points < winline || p2.Points < winline)
{
    p1.AddPoints(dice1.Throw() + dice2.Throw());
    p2.AddPoints(dice1.Throw() + dice2.Throw());
    round++;
}
