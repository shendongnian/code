`
public void Plan()
{
   foreach (var itemHeader in estimate.ItemHeaders)
   {
      if(itemHeader.Type == TypeEnum.Wall)
         foreach (var item in itemHeader.EstimateItems)
            ScheduleStair(item);
      else
         foreach (var item in itemHeader.EstimateItems)            
            ScheduleWall(item);
   }
}
`
This way you are directly calling the method and it can even be inlined.
