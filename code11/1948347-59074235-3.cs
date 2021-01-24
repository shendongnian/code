     Participant participant = new Participant(); // create new instance
     participant.GetParticipants(); // actual grab the file and parse it
     // here we actually group our participants based on your condition
     var query = participant.Participants.GroupBy(p => p.ParticipantTimeSlot).Select(pNew => new { SlotNumber = pNew.ToList()[0].ParticipantTimeSlot, Count = pNew.Count() });
         
     // finally write all the data out  
     Console.WriteLine(string.Join(Environment.NewLine, query.Select(a => $"Total Member Registered for Slot {a.SlotNumber}: {a.Count}")));
