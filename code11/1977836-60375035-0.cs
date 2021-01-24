        public class EcheqSubmissionBase
        {
            public string ValidUntilUtc { get; set; }
        }
        public class EcheqSubmissionStatus : EcheqSubmissionBase
        {
           public string NotCommonProperty { get; set; }
        }
        public class EcheqSubmissionInfoApi : EcheqSubmissionBase
        {
            public string NotCommonProperty { get; set; }
        }
