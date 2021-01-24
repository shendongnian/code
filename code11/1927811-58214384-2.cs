    public class ProposalViewModel
    {
        public int proposalId { get; set; }
    }
    public ActionResult AddLike(ProposalViewModel model)
    {   var propId = model.proposalId
        ...
    }
