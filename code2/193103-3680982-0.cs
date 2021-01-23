        //Test
        [Test]
        public void NetworkProviderShouldBeEmailedWhenBackHaulMaximumIsReached()
        {
            var mockRepo = new MockRepository();
            var apMock = mockRepo.PartialMock<AccessPoint>();
            using (mockRepo.Record())
            {
                Expect.Call(apMock.EmailNetworkProvider).Repeat.Once();
            }
            using (mockRepo.Playback())
            {
                apMock.BackHaulMaximum = 81;
                Assert.AreEqual(true, apMock.BackHaulMaximumReached());
            }
            mockRepo.VerifyAll();
        }
