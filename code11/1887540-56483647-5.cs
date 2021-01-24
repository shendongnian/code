        // Add performance anchor information.
        .Join(
            db.PerformanceAnchors,
            x => x.InitialTrainingAssociation.PerformanceAnchorId,
            pa => pa.Id,
            (x, PerformanceAnchor) =>
                new { x.InitialTrainingAssociation, x.InitialTraining, PerformanceAnchor }
        )
        // Add grading system information.
        .Join(
            db.GradingSystems,
            x => x.InitialTrainingAssociation.GradingSystemId,
            gs => gs.Id,
            // No need for InitialTrainingAssociation anymore, so we don't
            // include it in this final selector.
            (x, GradingSystem) =>
                new { x.InitialTraining, x.PerformanceAnchor, GradingSystem }
        );
