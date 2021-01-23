    public async void TaskSearchOnTaskList (SearchModel searchModel)
    {
        try
        {
		    List<EventsTasksModel> taskSearchList = await Task.Run(
                () => MakeasyncSearchRequest(searchModel),
                cancelTaskSearchToken.Token);
		    if (cancelTaskSearchToken.IsCancellationRequested
                    || string.IsNullOrEmpty(rid_agendaview_search_eventsbox.Text))
            {
		        return;
            }
		    if (taskSearchList == null || taskSearchList[0].result == Constants.ZERO)
            {
                RunOnUiThread(() => {
				    textViewNoMembers.Visibility = ViewStates.Visible;					
				    taskListView.Visibility = ViewStates.Gone;
				});
				taskSearchRecureList = null;
				return;
			}
            else
            {
                taskSearchRecureList = TaskFooterServiceLayer
                                           .GetRecurringEvent(taskSearchList);
				this.SetOnAdapter(taskSearchRecureList);
			}
		}
        catch (Exception ex)
        {
		    Console.WriteLine("ActivityTaskFooter -> TaskSearchOnTaskList:" + ex.Message);
        }
    }
