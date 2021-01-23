    var result = 
        phases
            .OfType<ServicePhase>()
            .Where(p => p.Service.Code == par.Service.Code)
            .Cast<ParPhase>()
            .Union(
                phases.OfType<ParTypePhase>()
                .Where(p => p.ParType.Code == par.Type.Code)
                .Cast<ParPhase>()
             );
