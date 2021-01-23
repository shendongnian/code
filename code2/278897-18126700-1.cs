    widgetCreator.Setup(wc => wc.Create(It.IsAny<Widget>(),
                                       It.IsAny<AnotherParam>())
                .Callback<Widget, AnotherParam>(
                  (w, ap) =>
                    {
                      Assert.AreEqual("Derived.Name", w.DerivedName);
                      Assert.IsTrue(w.SomeOtherCondition);
                      Assert.IsTrue(ap.AnotherCondition, "Oops");
                    });
    // *** Act => invoking the method on the CUT goes here
    // Assert + Verify
    widgetCreator.Verify(wc => wc.Create(It.IsAny<Widget>(), It.Is<AnotherParam>()),
      Times.Exactly(1));
