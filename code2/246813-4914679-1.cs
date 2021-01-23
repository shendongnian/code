    public ActionResult Reminders()
    {
        ReminderService reminderService = new ReminderService();
        ReminderType[] reminderTypes = reminderService.GetReminderTypes();
        SelectListItem[] selectListItems = _mappingService.Map(reminderTypes, reminderTypes.GetType(), typeof(SelectListItem[])) as SelectListItem[];
        RemindersViewModel remindersViewModel = new RemindersViewModel
                                                    {
                                                        Reminder = selectListItems,
                                                        SelectedReminder = ReminderType.CReminder
                                                    };
        return View(remindersViewModel);
    }
