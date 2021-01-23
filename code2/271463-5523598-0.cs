     class MyClass
     {
         public DateTime DateTimeMember {get;set;}
         // other stuff
     }
     var myObjects = new List<MyClass>();
     // fill list...
     // 3 possible things you might be interested in
     var myMinuteSum = myObjects.Sum(x => x.DateTimeMember.Minute);
     var mySecondSum = myObjects.Sum(x => x.DateTimeMember.Second);     
     var myOddTotalOfMinutesAndSecondsInSeconds = myObjects.Sum(x => x.DateTimeMember.Minute * 60 + x.DateTimeMember.Second);
