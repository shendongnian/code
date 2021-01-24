     var participantList = new List<string>();
    
            foreach (var community in communities)
            {
                foreach (var tournament in community.Tournaments)
                {
                    foreach (var round in tournament.Rounds)
                    {
                        foreach (var match in round.Matches)
                        {
                            if (match.Home.ParticipantId.IsNotNull())
                            {
                               participantList.Add(match.Home.ParticipantId); 
                            }
                            if (match.Away.ParticipantId.IsNotNull())
                            {
                               participantList.Add(match.Away.ParticipantId); 
                            }
                        }
    
                    }
                }
            }
