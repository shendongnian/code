(from b in dbContext.EwmBasins
								 where b.EwmB118VersionTypeId == dbContext.EwmB118VersionTypes.Max(m => m.b118VersionTypeId)
								 select new
								 {
									 Basin = b,
									 WellCount = b.Stations.Count(),
									 OrganizationCount = b.BasinPortions.Count(a => a.MonitoringNotificationBasins.Any(c => c.MonitoringNotification != null))
								 }
								).OrderBy(o => o.Basin.BasinCode)
