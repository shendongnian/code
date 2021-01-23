    private readonly IMilestoneService milestoneSerivce;
    public MilestoneController(IMilestoneService milestoneService)
    {
        this.milestoneService = milestoneService;
    }
    public ActionResult Milestone()
    {
        var result = milestoneService.GetMilestones();
        return View(result);
    }
