    var charmsAndCosts = context.Ioom_Charms
        .Where(c => c.xxxxx = whatever)
        .Select(c =>  new {
            Charm = c,
            Costs = String.Join(",", c.Ioom_CharmCosts.Select(cc => cc.charmCost.ToString()).ToArray())});
