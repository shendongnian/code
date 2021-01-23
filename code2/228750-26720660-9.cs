            var levelOptions = new ObservableCollection<GameLevelChoiceItem>();
            this.ViewModel[LevelOptionsViewModelKey] = levelOptions;
            var syllabus = await this.LevelRepository.GetSyllabusAsync();
            foreach (var level in syllabus.Levels)
            {
                foreach (var subLevel in level.SubLevels)
                {
                    var abilities = new List<GamePlayingAbility>(100);
                    foreach (var g in subLevel.Games)
                    {
                        var gwa = await this.MetricsRepository.GetGamePlayingAbilityAsync(g.Value);
                        abilities.Add(gwa);
                    }
                    double PlayingScore = AssessmentMetricsProcessor.ComputePlayingLevelAbility(abilities);
                    levelOptions.Add(new GameLevelChoiceItem()
                        {
                            LevelAbilityMetric = PlayingScore,
                            AbilityCaption = PlayingScore.ToString(),
                            LevelCaption = subLevel.Name,
                            LevelDescriptor = level.Ordinal + "." + subLevel.Ordinal,
                            LevelLevels = subLevel.Games.Select(g => g.Value),
                        });
 
                    await Task.Delay(100);
                }
            }
