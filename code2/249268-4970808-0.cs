    static void Main(string[] args)
    {
            using (MoveSaver objSaver = new MoveSaver(@"C:\1.bin"))
            {
                MoveAndTime[] MVobjects = new MoveAndTime[2];
                MoveAndTime mv1, mv2;
                mv2 = new MoveAndTime();
                mv1 = new MoveAndTime();
                mv1.MoveStruc = "1";
                mv1.timeHLd = DateTime.Now;
                
                mv2.MoveStruc = "2";
                mv2.timeHLd = DateTime.Now;
                MVobjects[0] = new MoveAndTime();
                MVobjects[0] = mv1;
                MVobjects[1] = new MoveAndTime();
                MVobjects[1] = mv2;
                
                objSaver.SaveToFile(MVobjects);
            }
            
            using (MoveSaver svrObj = new MoveSaver())
            {
                MoveAndTime[] MVTobjs = svrObj.DeSerializeObject(@"C:\1.bin");
                foreach (MoveAndTime item in MVTobjs)
                {
                    //Do Something
                    Console.WriteLine(item.MoveStruc);
                    Console.WriteLine(item.timeHLd);
                }
            }
        }
