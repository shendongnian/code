        public class EcheqSubmissionBase
        {
            public string ValidUntilUtc { get; set; }
        }
        public class EcheqSubmissionStatus : EcheqSubmissionBase
        {
           public string NonCommonPropertyX { get; set; }
        }
        public class EcheqSubmissionInfoApi : EcheqSubmissionBase
        {
            public string NonCommonPropertyY { get; set; }
        }
