    /// <summary>
    /// Gets the columns collection.
    /// </summary>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public ScheduleGridColumnCollection Columns
    {
        get
        {
            if (scheduleColumnsCollection == null)
            {
                if (scheduleColumnsArrayList == null)
                {
                    this.EnsureChildControls();
                    if (scheduleColumnsArrayList == null)
                        scheduleColumnsArrayList = new ArrayList();
                }
                scheduleColumnsCollection = new ScheduleGridColumnCollection(scheduleColumnsArrayList);
            }
            return scheduleColumnsCollection;
        }
    }
