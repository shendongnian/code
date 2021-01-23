    public decimal CalculateOwnCost(CustomerFrameVariationCategory cvfc)
    {
       return cfvc.FrameVariationCategory.FrameVariation.FrameVariationModules.Sum(fvm => // sum all frame variation modules
                     (lastValue4 ? 0 : fvm.FrameModule.FrameModuleValueChanges.Where(fmvc => fmvc.ChangeDateTime <= this.SelectedDateTime) // if module not active then 0
                     .OrderByDescending(fmvc2 => fmvc2.ChangeDateTime).FirstOrDefault().Porolone) + // otherwise get Porolone
                      fvm.FrameModule.FrameModuleComponents.Sum(fmc => // add to Porolone sum of all module components
                      (fmc.Article.ArticleDetails.Any() ? fmc.Article.ArticleDetails.Sum(ad => // if any article details then use A*L*W*T instead of Amount
                      WindowExcel.MultiplyArticleDetailValues(ad.ArticleDetailValueChanges.Where(advc => advc.ChangeDateTime <= this.SelectedDateTime)
                     .OrderByDescending(advc2 => advc2.ChangeDateTime).FirstOrDefault() ?? new ArticleDetailValueChange())) : 
                      WindowExcel.GetModuleComponentAmount(fmc.FrameModuleComponentValueChanges.Where(fmcvc => fmcvc.ChangeDateTime <= this.SelectedDateTime) // no details = get amount
                     .OrderByDescending(fmcvc2 => fmcvc2.ChangeDateTime).FirstOrDefault() ?? new FrameModuleComponentValueChange())) * // times article values
                      WindowExcel.MultiplyArticleValues(fmc.Article.ArticleValueChanges.Where(avc => avc.ChangeDateTime <= this.SelectedDateTime)
                      .OrderByDescending(avc2 => avc2.ChangeDateTime).FirstOrDefault() ?? new ArticleValueChange()))),
                  Cubes = cfvc.FrameVariationCategory.FrameVariation.FrameVariationModules.Sum(fvm => (fvm.FrameModule.FrameModuleValueChanges.Where(fmvc => fmvc.ChangeDateTime <= this.SelectedDateTime && fmvc.IsActive == true).OrderByDescending(fmvc2 => fmvc2.ChangeDateTime).FirstOrDefault() ?? new FrameModuleValueChange()).Cubes)
    }
