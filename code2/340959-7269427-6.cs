    public class MbusTelegramEqualityComparer : IEqualityComparer<MbusTelegram>{
            public static readonly MbusTelegramEqualityComparer Default = new MbusTelegramEqualityComparer();
            public bool Equals(MbusTelegram x, MbusTelegram y){
                return x.TimeStamp == y.TimeStamp;
            }
    
            public int GetHashCode(MbusTelegram obj){
                obj.TimeStamp.GetHashCode();
            }
        }
