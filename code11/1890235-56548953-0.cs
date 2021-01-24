cs
public static bool IsWaitingTime()
{
 if ( ( DateTime.Now.DayOfWeek == DayOfWeek.Saturday  || DateTime.Now.DayOfWeek == DayOfWeek.Sunday )
 && ( DateTime.Now.Hour <= 8 || DateTime.Now.Hour >= 18 ) 
 && DateTime.Now.Minute <= 9 ) 
   return true;
else
   return false;
} 
While Loop:
while ( IsWaitingTime )
    {
        Random waitTime = new Random();
        int milliseconds = waitTime.Next(120000, 180000);
        System.Threading.Thread.Sleep(milliseconds);
    }
This is one approach, as @JonH said, a date can't be both Saturday and Sunday simultaneously (in the same timezone at least).  chris-crush-code's anwser is also correct.
