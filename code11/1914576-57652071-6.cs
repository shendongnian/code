        // EXAMPLE FOR INITIALLY FILLING THE ARRAY
        for(var i = 0; i < StageAmount * LevelsPerStageAmount; i++)
        {
            // using integer division
            var stageID = i / StageAmount;
            // using modulo 
            // (starts over from 0 after exceeding LevelsPerStageAmount - 1)
            var levelID = i % LevelsPerStageAmount;
            var newLevelEntry = new LevelData;
            newLevelEntry.Completed = false;
            newLevelEntry.stars = -1;
            newLevelEntry.time = -1;
            newLevelEntry.unlocked = false;
            SaveManager.manager.levelData[stageID, levelID] = newLevelEntry;
        }
    so you can still use an overall flat index - you just have to remember how to calculate it.
