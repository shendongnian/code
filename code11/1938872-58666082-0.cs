C#
    Tower tower = new Tower();
    tower.Defence = sendDefence;
    _context.Update(tower);
    World world = new World();
    world.Player1Name = sendName;
    _context.Update(world);
you can query first then update value then call SaveChangesAsync.
C#
    Tower tower = _context.Tower.First(w=>w.Id == editViewModel.Tower.Id);
    tower.Defence = sendDefence;
    _context.Update(tower);
    World world = _context.World.First(w=>w.Id == editViewModel.World.Id);
    world.Player1Name = sendName;
    _context.Update(world);
