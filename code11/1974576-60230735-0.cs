    var attdefs = new List<Attdef>();
    for (int i = 0; i < editViewModel.TowerAttack.Count; i++) 
                {
                    tower = _context.Tower.First(m => m.TowerId == editViewModel.TowerId[i]);
                    tower.Attack -= editViewModel.TowerAttack[i];
                    _context.Update(tower);
                    attdefs.Add(new AttacDef { id = 0, Amount = attackSum }) ;
                }
                  _context.AddRange(attdefs); // don't remember exaxct syntaxt but this should be faster way
                  await _context.SaveChangesAsync(); 
