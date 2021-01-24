    if (eventRequestModel.Severity.Count > 0)
          {
            eventsModelList = (from job in _unitOfWork.Repository<Jobs>().Get(j => eventRequestModel.SiteIds.Contains(j.JobId.ToString())).Result
                               join ev in _unitOfWork.Repository<EventLogs>().Get(e => string.IsNullOrWhiteSpace(eventRequestModel.Description) ? true : e.Description.Contains(eventRequestModel.Description) 
                                                                                     //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
    						   && eventRequestModel.Severity.Contains(e.Severity.ToString())).Result on job.JobId equals ev.JobId
                               join pnl in _unitOfWork.Repository<Panels>().Get(el => eventRequestModel.SiteIds.Contains(el.JobId.ToString())).Result on ev.PanelId equals pnl.PanelId
                               orderby ev.TimeStamp descending, ev.EventId descending
                               select new EventsModel
                               {
                                 UTCTimeStamp = ev.TimeStamp,
                                 EventType = ev.EventType,
                                 Description = ev.Description,
                                 PanelName = pnl.Name,
                                 SiteName = job.Name,
                                 ChannelGuid = ev.ChannelGuid,
                                 MapGuid = ev.MapGuid,
                                 Severity = ev.Severity,
                                 LogType = ev.LogType,
                                 Data1 = ev.Data1,
                                 Data2 = ev.Data2,
                                 Data3 = ev.Data3,
                                 Data4 = ev.Data4,
                                 PanelItemType = ev.PanelItemType,
                                 PanelItemId = ev.PanelItemId
                               }).Take(numOfItems).ToList();
          }
          else
          {
            eventsModelList = (from job in _unitOfWork.Repository<Jobs>().Get(j => eventRequestModel.SiteIds.Contains(j.JobId.ToString())).Result
                               join ev in _unitOfWork.Repository<EventLogs>().Get(e => string.IsNullOrWhiteSpace(eventRequestModel.Description) ? true : e.Description.Contains(eventRequestModel.Description) 
    						   && eventRequestModel.Severity.Contains(e.Severity.ToString())).Result on job.JobId equals ev.JobId
                               join pnl in _unitOfWork.Repository<Panels>().Get(el => eventRequestModel.SiteIds.Contains(el.JobId.ToString())).Result on ev.PanelId equals pnl.PanelId
                               orderby ev.TimeStamp descending, ev.EventId descending
                               select new EventsModel
                               {
                                 UTCTimeStamp = ev.TimeStamp,
                                 EventType = ev.EventType,
                                 Description = ev.Description,
                                 PanelName = pnl.Name,
                                 SiteName = job.Name,
                                 ChannelGuid = ev.ChannelGuid,
                                 MapGuid = ev.MapGuid,
                                 Severity = ev.Severity,
                                 LogType = ev.LogType,
                                 Data1 = ev.Data1,
                                 Data2 = ev.Data2,
                                 Data3 = ev.Data3,
                                 Data4 = ev.Data4,
                                 PanelItemType = ev.PanelItemType,
                                 PanelItemId = ev.PanelItemId
                               }).Take(numOfItems).ToList();
          }
        }
