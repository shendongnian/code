    using System.Linq;
    ...
    var before = selectedGameObjects.Select(obj => new ObjectState(obj)).ToList();
    //TODO Apply all your changes to all the selected objects 
    var after = selectedGameObjects.Select(obj => new ObjectState(obj)).ToList();
    UndoRedo.AddAction(new UndoableChange(before, after));
