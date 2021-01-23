    int listCountAtTimeOfCall = 0;
    mockSomeRepository.Setup(
        m => m.Write(It.IsAny<IEnumerable<SomeDTO>>())).Callback
            <IEnumerable<SomeDTO>>(list => listCountAtTimeOfCall = list.Count());
    ... do the work ...
    Assert.AreEqual(listCountAtTimeOfCall, 25);
