    public async Task LoadTaskManagerPageAsynnc()
    {
        await this.ActivateItemAsync(new TaskManagerViewModel(this.LoggedUser, this.repository));
        if (!this.LoggedUser.GetUserTask().IsTaskTakenByUser())
        {
            //logic
        }
    }
