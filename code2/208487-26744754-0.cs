    	[Test]
		public void RhinoMock_PerformMultipleChecks()
		{
			var myMock = MockRepository.GenerateDynamicMockWithRemoting<IComparable>();
			// first round of checks
			myMock.Expect(x => x.CompareTo("123")).Return(1);
			myMock.Expect(x => x.CompareTo("-12")).Return(-1);
			Assert.AreEqual(1, myMock.CompareTo("123"));
			Assert.AreEqual(-1, myMock.CompareTo("-12"));
			myMock.VerifyAllExpectations();
			// reset
			myMock.BackToRecord();
			myMock.Replay();
			// next round of checks
			myMock.Expect(x => x.CompareTo(1.23)).Return(1);
			myMock.Expect(x => x.CompareTo(-12)).Return(-1);
			Assert.AreEqual(1, myMock.CompareTo(1.23));
			Assert.AreEqual(-1, myMock.CompareTo(-12));
			myMock.VerifyAllExpectations();
			// reset
			myMock.BackToRecord();
			myMock.Replay();
			// final round of checks
			myMock.Expect(x => x.CompareTo(1.23m)).Return(1);
			myMock.Expect(x => x.CompareTo(-12m)).Return(-111);
			Assert.AreEqual(1, myMock.CompareTo(1.23m));
			Assert.AreEqual(-111, myMock.CompareTo(-12m));
			myMock.VerifyAllExpectations();
		}
