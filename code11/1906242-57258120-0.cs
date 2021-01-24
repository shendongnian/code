    class ProgramState
    {
        public bool UserAcceptedAgreement { get; set; }
        public bool UserAcknowledgedLiability { get; set; }
        public bool UserSubmittedSignature { get; set; }
        public bool EverythingAccepted =>
            UserSubmittedSignature &&
            UserAcknowledgedLiability &&
            UserSubmittedSignature;
    }
