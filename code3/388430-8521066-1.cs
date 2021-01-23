    MoveUnitCommand  // a unit is a graphic piece on a game board
    + UnitId
    + Destination
    + Execute()
      {
          units = Units.Find(UnitId)
          prevCoords = units.Position
          units.Position = Destination
      }
    + CanUndo() { return true; }
    + Undo()
      {
          units = Units.Find(UnitId)
          units.Position = prevCoords 
      }
    + etc, etc
