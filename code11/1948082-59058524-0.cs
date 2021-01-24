while (true)
{
   try
   {
        // do something
   }
   catch (Exception ex)
   {
        // save log 
   }
   Thread.Sleep(TimeSpan.FromMilliseconds(TimeSpan.FromMinutes(10).TotalMilliseconds));
}
