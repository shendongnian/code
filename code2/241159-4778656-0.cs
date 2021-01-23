    var query = from pred in Predictions
                group pred.Points by pred.WeekNum into week
                join pred in Predictions
                    on new { WeekNum = week.Key, Points = week.Max() }
                    equals new { pred.WeekNum, pred.Points }
                group 1 by pred.Player into player
                let Points = player.Count()
                orderby Points descending, player.Key
                select new
                {
                    Player = player.Key,
                    Points,
                };
