    public class GameActivity
    {
            public virtual DateTime Date { get; set; }
            public virtual string GameRoundId { get; set; }
            public virtual int GameProvider { get; set; }
            public virtual string GameName { get; set; }
            public virtual decimal RealBet { get; set; }
            public virtual decimal RealWin { get; set; }
            public virtual decimal BonusBet { get; set; }
            public virtual decimal BonusWin { get; set; }
            public virtual decimal BonusContribution { get; set; }
            public virtual int IsRoundCompleted { get; set; }
            public virtual int IsRoundCancelled { get; set; }
    }
