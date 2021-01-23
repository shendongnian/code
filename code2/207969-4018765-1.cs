    public partial class WindowExcel
	{
		private static decimal GetOwnCost(CustomerFrameVariationCategory cfvc, bool frameModuleAnyNonActive, DateTime selectedDateTime)
		{
			return cfvc.FrameVariationCategory.FrameVariation.FrameVariationModules.Sum(fvm => // sum all frame variation modules
				(frameModuleAnyNonActive ? 0 : fvm.FrameModule.FrameModuleValueChanges.Where(fmvc => fmvc.ChangeDateTime <= selectedDateTime) // if module not active then 0
				.OrderByDescending(fmvc2 => fmvc2.ChangeDateTime).FirstOrDefault().Porolone) + // otherwise get Porolone
				fvm.FrameModule.FrameModuleComponents.Sum(fmc => // add to Porolone sum of all module components
					(fmc.Article.ArticleDetails.Any() ? fmc.Article.ArticleDetails.Sum(ad => // if any article details then use A*L*W*T instead of Amount
						WindowExcel.MultiplyArticleDetailValues(ad.ArticleDetailValueChanges.Where(advc => advc.ChangeDateTime <= selectedDateTime)
						.OrderByDescending(advc2 => advc2.ChangeDateTime).FirstOrDefault() ?? new ArticleDetailValueChange())) :
						WindowExcel.GetModuleComponentAmount(fmc.FrameModuleComponentValueChanges.Where(fmcvc => fmcvc.ChangeDateTime <= selectedDateTime) // no details = get amount
						.OrderByDescending(fmcvc2 => fmcvc2.ChangeDateTime).FirstOrDefault() ?? new FrameModuleComponentValueChange())) * // times article values
						WindowExcel.MultiplyArticleValues(fmc.Article.ArticleValueChanges.Where(avc => avc.ChangeDateTime <= selectedDateTime)
						.OrderByDescending(avc2 => avc2.ChangeDateTime).FirstOrDefault() ?? new ArticleValueChange())));
		}
	}
