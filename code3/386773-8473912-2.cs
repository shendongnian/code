    public class PJAwardsViewModelHelper
    {
        public static PJAwardsViewModel PopulatePJAwardsViewModel(PJAwards pjaward)
        {
            return new PJAwardsViewModel
            {
                Id = pjaward.Id,
                NominatorFName = pjaward.PJUsers.FirstName,
                NomineeFname = pjaward.PJUsers1.FirstName,
                AwardName = pjaward.PJAwartypes.AwardName,
                IsAwarded = pjaward.IsAwarded
            };
        }
    
        public static List<PJAwardsViewModel> PopulatePJAwardsViewModelList(List<PJAwards> pjawardsList)
        {
            return pjawardsList.Select(x => PopulatePJAwardsViewModel(x)).ToList();
        }
    }
