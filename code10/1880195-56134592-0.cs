    [TestMethod]
    public void validation_elements_are_added_to_only_one_dictionary()
    {
        var elementOne = new Validation_Element {Id = "A", Time = 1 };
        var elementTwo = new Validation_Element { Id = "B" , Time = 2};
        var elementThree = new Validation_Element { Id = "A" , Time = 3};
        var subject = new Validator_Counter_Model(new Dictionary<string, Info_Model>());
        subject.Add(elementOne);
        subject.Add(elementTwo);
        subject.Add(elementThree);
        var output = subject.map;
        var elementsWithId_A = output["A"];
        var elementsWithId_B = output["B"];
        var id_a_innerList = elementsWithId_A[new DateTime(2000, 1, 1)];
        var id_b_innerList = elementsWithId_B[new DateTime(2000, 1, 1)];
        Assert.AreEqual(2, id_a_innerList.Count);
        Assert.AreEqual(1, id_b_innerList.Count);
    }
