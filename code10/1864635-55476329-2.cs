     mission.OnMissionStart += (sender) =>
     {
         Console.WriteLine($"This is {sender.Name}");
         
         switch (sender) {
             case MissionA a:
                 Console.WriteLine(a.SomeSpecificMissionAMember);
                 break;
             case MissionB b:
                 Console.WriteLine(b.SomeSpecificMissionAMember);
                 break; }
     }
