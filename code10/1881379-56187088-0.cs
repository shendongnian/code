C#
Task task = Task.Run(async () =>
{
  while (true)
  {
    _cancellationToken.ThrowIfCancellationRequested();
    ...
       //for all horses in the race
       for (int h = 0; h < _allRaces[j].HorseList.Count; h++)
       {
          _cancellationToken.ThrowIfCancellationRequested();
          HorseDataWrapper horse = new HorseDataWrapper();
          horse = ParseHorseData(_allRaces[j].HorseList[h], _allRaces[j].RaceDate);
          _allRaces[j].HorseList[h] = horse;
       }
    ...
  }
});
