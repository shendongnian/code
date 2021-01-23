    var custFVC = (from cfvc in customer.CustomerFrameVariationCategories
                   let lastValue = cfvc.CustomerFrameVariationCategoryValueChanges.Where(cfvcvc => cfvcvc.ChangeDateTime <= this.SelectedDateTime).OrderByDescending(cfvcvc2 => cfvcvc2.ChangeDateTime).FirstOrDefault() ?? new CustomerFrameVariationCategoryValueChange()
                   let lastValue2 = cfvc.FrameVariationCategory.FrameVariation.Frame.FrameValueChanges.Where(fvc => fvc.ChangeDateTime <= this.SelectedDateTime).OrderByDescending(fvc2 => fvc2.ChangeDateTime).FirstOrDefault() ?? new FrameValueChange()
                   let lastValue3 = cfvc.FrameVariationCategory.FrameVariationCategoryValueChanges.Where(fvcvc => fvcvc.ChangeDateTime <= this.SelectedDateTime).OrderByDescending(fvcvc2 => fvcvc2.ChangeDateTime).FirstOrDefault() ?? new FrameVariationCategoryValueChange()
                   let lastValue4 = cfvc.FrameVariationCategory.FrameVariation.FrameVariationModules.Any(fvm => (fvm.FrameModule.FrameModuleValueChanges.Where(fmvc => fmvc.ChangeDateTime <= this.SelectedDateTime).OrderByDescending(fmvc2 => fmvc2.ChangeDateTime).FirstOrDefault() ?? new FrameModuleValueChange()).IsActive == false)
                   where lastValue.IsActive == true
                   orderby cfvc.FrameVariationCategory.FrameVariation.Frame.Name, cfvc.FrameVariationCategory.Category.Name, cfvc.FrameVariationCategory.FrameVariation.Name
                   select new
                   { cfvc, lastValue, lastValue1, lastValue2, lastValue3}).ToList();
