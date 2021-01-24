    var data = new leapserverdbContext().TbUserActivity
			.OrderByDescending(id => id.UserActivityId)
			.Select(sel => new
			{
				sel.UserActivityId,
				sel.TbDevice.DeviceId,
				Name = sel.TbDevice.TbDeviceBrand.Name + " " + sel.TbDevice.Name +
					" " + sel.TbDevice.TbDeviceYear.Year + " " + sel.TbDevice.TbDeviceSize.Size,
				sel.TbDevice.IconResource
			})
			.GroupBy(x => x.Name)
			.Select(g => g.First())
			.ToList();
