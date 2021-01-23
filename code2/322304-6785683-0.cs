    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;
    using SeaRisenLib2.Text;
    using XmlLib;
    
    /// <summary>
    /// Summary description for HoneyPot
    /// </summary>
    public class HoneyPot
    {
        private const string KEY = "blacklistkey"; // blacklist key - need to register at httpbl.org to get it
        private const string HTTPBL = "dnsbl.httpbl.org"; // blacklist lookup host
    public HoneyPot()
    {
    }
    public static Score GetScore_ByIP(string ip)
    {
        string sendMsg = "", receiveMsg = "";
        int errorCount = 0; // track where in try/catch we fail for debugging
        try
        {
            // for testing: ip = "188.143.232.31";
            //ip = "173.242.116.72";
            if ("127.0.0.1" == ip) return null; // localhost development computer
            IPAddress address;
            if (!IPAddress.TryParse(ip, out address))
                throw new Exception("Invalid IP address to HoneyPot.GetScore_ByIP:" + ip);
            errorCount++; // 1
            string reverseIP = ip.ToArray('.').Reverse().ToStringCSV(".");
            sendMsg = string.Format("{0}.{1}.{2}", KEY, reverseIP, HTTPBL);
            errorCount++; // 2
            //IPHostEntry value = Dns.GetHostByName(sendMsg);
            IPHostEntry value = Dns.GetHostEntry(sendMsg);
            errorCount++; // 3
            address = value.AddressList[0];
            errorCount++; // 4
            receiveMsg = address.ToString();
            errorCount++; // 5
            int[] ipArray = receiveMsg.ToArray('.').Select(s => Convert.ToInt32(s)).ToArray();
            errorCount++; // 6
            if (127 != ipArray[0]) // error
                throw new Exception("HoneyPot error");
            errorCount++; // 7
            Score score = new Score()
            {
                DaysSinceLastSeen = ipArray[1],
                Threat = ipArray[2],
                BotType = ipArray[3]
            };
            errorCount++; // 8
            return score;
        }
        catch (Exception ex)
        {
            Log.Using("VisitorLog/HoneyPotErrors", log =>
            {
                log.SetString("IPrequest", ip);
                log.SetString("SendMsg", sendMsg, XmlFile.ELEMENT);
                log.SetString("RecvMsg", receiveMsg, XmlFile.ELEMENT);
                log.SetString("Exception", ex.Message, XmlFile.ELEMENT);
                log.SetString("ErrorCount", errorCount.ToString());
            });
        }
        return null;
    }
    // Bitwise values
    public enum BotTypeEnum : int
    {
        SearchEngine = 0,
        Suspicious = 1,
        Harvester = 2,
        CommentSpammer = 4
    }
    public class Score
    {
        public Score()
        {
            BotType = -1;
            DaysSinceLastSeen = -1;
            Threat = -1;
        }
        public int DaysSinceLastSeen { get; internal set; }
        public int Threat { get; internal set; }
        /// <summary>
        /// Use BotTypeEnum to understand value.
        /// </summary>
        public int BotType { get; internal set; }
        /// <summary>
        /// Convert HoneyPot Score values to String (DaysSinceLastSeen.Threat.BotType)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}",
                DaysSinceLastSeen,
                Threat,
                BotType);
        }
        public static explicit operator XElement(Score score)
        {
            XElement xpot = new XElement("HoneyPot");
            if (null != score)
            {
                if (score.DaysSinceLastSeen >= 0)
                    xpot.SetString("Days", score.DaysSinceLastSeen);
                if (score.Threat >= 0)
                    xpot.SetString("Threat", score.Threat);
                if (score.BotType >= 0)
                    xpot.SetString("Type", score.BotType);
                foreach (BotTypeEnum t in Enum.GetValues(typeof(BotTypeEnum)))
                {
                    // Log enum values as string for each bitwise value represented in score.BotType
                    int value = (int)t;
                    if ((value == score.BotType) || ((value & score.BotType) > 0))
                        xpot.GetCategory(t.ToString());
                }
            }
            return xpot;
        }
        public static explicit operator Score(XElement xpot)
        {
            Score score = null;
            if (null != xpot)
                score = new Score()
                {
                    DaysSinceLastSeen = xpot.GetInt("Days"),
                    Threat = xpot.GetInt("Threat"),
                    BotType = xpot.GetInt("Type")
                };
            return score;
        }
    }
    /// <summary>
    /// Log score value to HoneyPot child Element (if score not null).
    /// </summary>
    /// <param name="score"></param>
    /// <param name="parent"></param>
    public static void LogScore(HoneyPot.Score score, XElement parent)
    {
        if ((null != score) && (null != parent))
        {
            parent.Add((XElement)score);
        }
    }
}
