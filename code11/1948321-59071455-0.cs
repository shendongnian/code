C#
var collapsed = elements.GroupBy(elm => new{
   OrderIdentifier=elm.OrderIdentifier,
   EfterFladderOpstilTid=elm.EfterFladderOpstilTid,
   EfterRadanOpstilTid=elm.EfterRadanOpstilTid
})
   .Select(group => new ModelsBase.Laser.Element()
		{
			CuttingDurationInSeconds = group.Sum(itm => itm.CuttingDurationInSeconds),
			FladderDurationInSeconds = group.Sum(itm => itm.FladderDurationInSeconds),
			DeliveryDate = group.Min(itm => itm.DeliveryDate),
			EfterFladderOpstilTid = group.Key.EfterFladderOpstilTid,
			EfterRadanOpstilTid   = group.Key.EfterRadanOpstilTid,
		});
Or by using LET statement
C#
var collapsed = from groupedElement in 
			 			(from element in elements
			 			 group  element by element.OrderIdentifier into g
						select g)
			 			let First = groupedElement.First()
			 			select  new ModelsBase.Laser.Element()
						{
							CuttingDurationInSeconds = groupedElement.Sum(itm => itm.CuttingDurationInSeconds),
							FladderDurationInSeconds = groupedElement.Sum(itm => itm.FladderDurationInSeconds),
							DeliveryDate = groupedElement.Min(itm => itm.DeliveryDate),
							EfterFladderOpstilTid = First.EfterFladderOpstilTid,
							EfterRadanOpstilTid = First.EfterRadanOpstilTid
						};
