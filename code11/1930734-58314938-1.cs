if (CompareDate.CompareTimespan() > 0)
{
  DownloadData.GetFromApi(...);
  return; <---- 
}
 if (CompareDate.CompareTimespan() > 0)
{
   DownloadData.GetFromApi(...);
  return; <----
}
----
Option 2 as I'm still not sure what you after. 
if( CompareDate.CompareDateTime() >= 0) 
{
  DownloadData.GetFromApi("devicetypes", "7654321234",...)
}
else 
{
  while (CompareDate.CompareDateTime() < 0)
  {
     ...
  }
  // Nothing here
}
