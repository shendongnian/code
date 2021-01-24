    var initialTrainingResults =
        // Start with the InitialTrainings data.
        db.InitialTrainings
        // Add association information.
        .Join(
            // The table we want to join with
            db.InitialTrainingAssociations,
            // Key selector for the outer type (the one initiating the join,
            // in this case InitialTraining)
            it => it.Id,
            
            // Key selector for the inner type (the one being joined with,
            // in this case InitialTrainingAssociation)
            ita => ita.InitialTrainingId,
            
            // Result selector. This defines how we store the joined data.
            // We store the results in an anonymous type, so that we can
            // use the intermediate data without having to declare a new class.
            (InitialTraining, InitialTrainingAssociation) =>
                new { InitialTraining, InitialTrainingAssociation }
        )
        // Add performance anchor information.
        .Join(
            db.CodePerformanceAnchors,
            x => x.InitialTrainingAssociation.PerformanceAnchorId,
            cpa => cpa.Id,
            (x, CodePerformanceAnchor) =>
                new { x.InitialTrainingAssociation, x.InitialTraining, CodePerformanceAnchor }
        )
        // Add grading system information.
        .Join(
            db.GradingSystems,
            x => x.InitialTrainingAssociation.GradingSystemId,
            gs => gs.Id,
            // No need for InitialTrainingAssociation anymore, so we don't
            // include in in this final selector.
            (x, GradingSystem) => new { x.InitialTraining, x.CodePerformanceAnchor, GradingSystem }
        );
