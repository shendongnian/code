    Manager test = new Manager();
    
                Medium medium = new Medium() {isMoving = true,Name = "medium", UpgradedName = "mediaum name"};
                //some items in array
                test.enemies = new BigBase[] {medium,new Small{isMoving = false},new Small{isMoving = true}, new BigBase {Name = "bigbase", isMoving = true}, new BigBase {Name = "bigbase2", isMoving = true}, new BigBase {Name = "bigbase3", isMoving = true}} ;
    
                DataContractSerializer serializer = new DataContractSerializer(typeof (Manager));
                FileStream writer = new FileStream("test123.txt", FileMode.Create);
                serializer.WriteObject(writer, test);
                writer.Close();
                writer = new FileStream("test123.txt", FileMode.Open);
                Manager deserializedmanager = serializer.ReadObject(writer) as Manager;
                //verify serialized object
                Console.WriteLine("medium object:"+ (deserializedmanager.enemies[0]  as Medium).UpgradedName);
