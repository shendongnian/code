	var winningConditions = new[] {
		scenarioA,
		scenarioB,
		scenarioC,
		// ...
	};
	
	var hasPlayerOWon = winningConditions.Any(placements => placements.All(clickedCellsO.Contains));
	var hasPlayerXWon = winningConditions.Any(placements => placements.All(clickedCellsX.Contains));
