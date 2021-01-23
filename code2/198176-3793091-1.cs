    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Xml.Serialization;
    using ProtoBuf.Meta;
    
    
    static class Program
    {
        static void Main()
        {
            var orig = new Game {
                 Finished = true, GameGUID = Guid.NewGuid(), GameID = 12345, GameSetup = false, MaximumCardsInDeck = 20,
                 Player = new Player { Name = "Fred"}, Player1 = new Player { Name = "Barney"}, Player1Connected = true,
                 Player1EnvironmentSetup = true, Player1ID = 12345, Player1Won = 3, Player2Connected = true, Player2EnvironmentSetup = true,
                 Player2ID = 23456, Player2Won = 0, Round = 4, RoundsToWin = 5, Started = true, StateXML = "not really xml",
                 TimeEnded = null, TimeLimitPerTurn = 500, TimeStamp = new byte[] {1,2,3,4,5,6}, TimeStarted = DateTime.Today};
            const int LOOP = 50000;
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            using (var ms = new MemoryStream())
            {
                var ser = new BinaryFormatter();
                Console.WriteLine();
                Console.WriteLine(ser.GetType().Name);
                ser.Serialize(ms, orig);
                Console.WriteLine("Length: " + ms.Length);
                ms.Position = 0;
                ser.Deserialize(ms);
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    ser.Serialize(ms, orig);
                }
                watch.Stop();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ser.Deserialize(ms);
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            using (var ms = new MemoryStream())
            {
                var ser = new XmlSerializer(typeof(Game));
                Console.WriteLine();
                Console.WriteLine(ser.GetType().Name);
                ser.Serialize(ms, orig);
                Console.WriteLine("Length: " + ms.Length);
                ms.Position = 0;
                ser.Deserialize(ms);
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    ser.Serialize(ms, orig);
                }
                watch.Stop();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ser.Deserialize(ms);
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractSerializer(typeof(Game));
                Console.WriteLine();
                Console.WriteLine(ser.GetType().Name);
                ser.WriteObject(ms, orig);
                Console.WriteLine("Length: " + ms.Length);
                ms.Position = 0;
                ser.ReadObject(ms);
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    ser.WriteObject(ms, orig);
                }
                watch.Stop();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ser.ReadObject(ms);
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            using (var ms = new MemoryStream())
            {
                var ser = new NetDataContractSerializer();
                Console.WriteLine();
                Console.WriteLine(ser.GetType().Name);
                ser.Serialize(ms, orig);
                Console.WriteLine("Length: " + ms.Length);
                ms.Position = 0;
                ser.Deserialize(ms);
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    ser.Serialize(ms, orig);
                }
                watch.Stop();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ser.Deserialize(ms);
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            {
                var sb = new StringBuilder();
                var ser = new JavaScriptSerializer();
                Console.WriteLine();
                Console.WriteLine(ser.GetType().Name);
                ser.Serialize(orig, sb);
                Console.WriteLine("Length: " + sb.Length);
                ser.Deserialize(sb.ToString(), typeof(Game));
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    sb.Length = 0;
                    ser.Serialize(orig, sb);
                }
                watch.Stop();
                string s = sb.ToString();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ser.Deserialize(s, typeof(Game));
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            using (var ms = new MemoryStream())
            {
                var ser = CreateProto();
                Console.WriteLine();
                Console.WriteLine("(protobuf-net v2)");
                ser.Serialize(ms, orig);
                Console.WriteLine("Length: " + ms.Length);
                ms.Position = 0;
                ser.Deserialize(ms, null, typeof(Game));
    
                var watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ms.SetLength(0);
                    ser.Serialize(ms, orig);
                }
                watch.Stop();
                Console.WriteLine("Serialize: " + watch.ElapsedMilliseconds);
                watch = Stopwatch.StartNew();
                for (int i = 0; i < LOOP; i++)
                {
                    ms.Position = 0;
                    ser.Deserialize(ms, null, typeof(Game));
                }
                watch.Stop();
                Console.WriteLine("Deserialize: " + watch.ElapsedMilliseconds);
            }
    
            Console.WriteLine();
            Console.WriteLine("All done; any key to exit");
            Console.ReadKey();
        }
        static TypeModel CreateProto()
        {
            var meta = TypeModel.Create();
            meta.Add(typeof(Game), false).Add(Array.ConvertAll(typeof(Game).GetProperties(),prop=>prop.Name));
            meta.Add(typeof(Player), false).Add(Array.ConvertAll(typeof(Player).GetProperties(),prop=>prop.Name));
            return meta.Compile();
        }
    }
    
    [Serializable, DataContract]
    public partial class Game
    {
        [DataMember]
        public bool Finished { get; set; }
        [DataMember]
        public Guid GameGUID { get; set; }
        [DataMember]
        public long GameID { get; set; }
        [DataMember]
        public bool GameSetup { get; set; }
        [DataMember]
        public Nullable<int> MaximumCardsInDeck { get; set; }
        [DataMember]
        public Player Player { get; set; }
        [DataMember]
        public Player Player1 { get; set; }
        [DataMember]
        public bool Player1Connected { get; set; }
        [DataMember]
        public bool Player1EnvironmentSetup { get; set; }
        [DataMember]
        public long Player1ID { get; set; }
        [DataMember]
        public int Player1Won { get; set; }
        [DataMember]
        public bool Player2Connected { get; set; }
        [DataMember]
        public bool Player2EnvironmentSetup { get; set; }
        [DataMember]
        public long Player2ID { get; set; }
        [DataMember]
        public int Player2Won { get; set; }
        [DataMember]
        public int Round { get; set; }
        [DataMember]
        public Nullable<int> RoundsToWin { get; set; }
        [DataMember]
        public bool Started { get; set; }
        [DataMember]
        public string StateXML { get; set; }
        [DataMember]
        public Nullable<DateTime> TimeEnded { get; set; }
        [DataMember]
        public Nullable<int> TimeLimitPerTurn { get; set; }
        [DataMember]
        public byte[] TimeStamp { get; set; }
        [DataMember]
        public Nullable<DateTime> TimeStarted { get; set; }
    }
    [Serializable, DataContract]
    public class Player
    {
        [DataMember]
        public string Name { get; set; }
    }
