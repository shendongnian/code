    class TestResult : ClientApplication.TestResult
    {
        int PersonId { get; set; }
        override bool IsFollowUp(ClientApplication.TestResult prevTest)
        {
              // Your own implementation or trivial (base.IsFollowUp(ClientApplication.TestResult.prevTest.trShared)
        }
    }
