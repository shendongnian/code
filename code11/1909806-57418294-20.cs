    //display helper's Schedule 
    Console.WriteLine("--------------------------------------");
    for (int i = 0; i < helpersSchedule.Count; i++) {
        Console.WriteLine("Helper n.{0}:", i);
        foreach (int[] helperEvent in helpersSchedule[i]) {
            //Console.WriteLine("\tfamily n.{0}: {1} - {2}", helperEvent[0], helperEvent[1], helperEvent[2]);
            Console.WriteLine("\tfamily n.{0}: {1:00}:{2:00} - {3:00}:{4:00}", helperEvent[0], helperEvent[1] / 60, helperEvent[1] % 60, helperEvent[2] / 60, helperEvent[2] % 60);
        }
    }
    Console.ReadKey();
