    [TestClass]
    public class PersonalNumberFixture
    {
        [TestMethod]
        public void Ctor_PersonalNumber_AsUnformatted()
        {
            AssertExpectedNumber("7102240475", "7102240475");
            AssertExpectedNumber("197102240475", "7102240475");
            AssertExpectedNumber("19710224-0475", "7102240475");
            AssertExpectedNumber("710224-0475", "7102240475");
        }
        private static void AssertExpectedNumber(string number, string expectedNumber)
        {
            Assert.AreEqual(expectedNumber, new PersonalNumber(number).Number);
        }
        [TestMethod]
        public void FiltersAndRemovesPlusAndMinusCharactersCorrectly()
        {
            Assert.AreEqual("7102240475", new PersonalNumber("710224-0475").Number);
            Assert.AreEqual("7102240475", new PersonalNumber("710224+0475").Number);
            Assert.AreEqual("7102240475", new PersonalNumber("19710224-0475").Number);
            Assert.AreEqual("7102240475", new PersonalNumber("19710224+0475").Number);
        }
        [TestMethod]
        public void PlusAndMinusCharactersOnlyAllowedInCertainPositions()
        {
            Assert.IsTrue(new PersonalNumber("710224-0475").IsValid);
            Assert.IsTrue(new PersonalNumber("710224+0475").IsValid);
            Assert.IsFalse(new PersonalNumber("71022404-75").IsValid);
            Assert.IsFalse(new PersonalNumber("71022404+75").IsValid);
            Assert.IsFalse(new PersonalNumber("710-224-0475").IsValid);
            Assert.IsFalse(new PersonalNumber("710224+04+75").IsValid);
        }
        [TestMethod]
        public void MaleAndFemale_CorrectlyIdentified()
        {
            // female
            Assert.IsFalse(new PersonalNumber("551213-7986").IsMale);
            Assert.IsTrue(new PersonalNumber("551213-7986").IsFemale);
            // male
            Assert.IsTrue(new PersonalNumber("710224-0475").IsMale);
            Assert.IsFalse(new PersonalNumber("710224-0475").IsFemale);
            Assert.IsTrue(new PersonalNumber("19710224-0475").IsMale);
            Assert.IsFalse(new PersonalNumber("19710224-0475").IsFemale);
        }
        [TestMethod]
        public void Ctor_ValidPersonalNumbers_ParsedAsValid()
        {
            TestLoop_ValidPersonalNumbers(new[] { "7102240475", "197102240475", "19710224-0475", "710224-0475", "801231+3535", "630215" });
        }
        private static void TestLoop_ValidPersonalNumbers(IEnumerable<string> personalNumbers)
        {
            foreach (var personalNumber in personalNumbers)
            {
                var pn = new PersonalNumber(personalNumber);
                Assert.IsTrue(pn.IsValid, string.Format("Pno = '{0}'", personalNumber));
            }
        }
        [TestMethod]
        public void ToString_EqualsNormalizedNumber()
        {
            Assert.AreEqual(new PersonalNumber("460126").ToString(), new PersonalNumber("460126").Number);
        }
        [TestMethod]
        public void Ctor_InvalidPersonalNumbers_ParsedAsNotValid()
        {
            TestLoop_InvalidPersonalNumbers(new[] { "127102240475", "19710XY40475", "19710224=0475", "1971", "14532436-45", "556194-7986", "262000-0113", "460531-12" });
        }
        private static void TestLoop_InvalidPersonalNumbers(IEnumerable<string> personalNumbers)
        {
            foreach (var personalNumber in personalNumbers)
            {
                var pn = new PersonalNumber(personalNumber);
                Assert.IsFalse(pn.IsValid, string.Format("Pno = '{0}'", personalNumber));
            }
        }
        [TestMethod]
        public void TwoNumbers_ConsideredEqual_IfNormalizedNumbersAreEqual()
        {
            new PersonalNumber("710224-0475");
            Assert.IsTrue(new PersonalNumber("800212").Equals(new PersonalNumber("19800212")));
            Assert.IsTrue(new PersonalNumber("800212").Equals(new PersonalNumber("800212")));
            Assert.IsTrue(new PersonalNumber("8002121234").Equals(new PersonalNumber("19800212-1234")));
            Assert.IsFalse(new PersonalNumber("800212").Equals(new PersonalNumber("900212")));
        }
        [TestMethod]
        public void EqualsOperatorOverloaded_AsEquals()
        {
            Assert.IsTrue(new PersonalNumber("800212") == new PersonalNumber("19800212"));
            Assert.IsTrue(new PersonalNumber("800212") == new PersonalNumber("800212"));
            Assert.IsTrue(new PersonalNumber("8002121234") == new PersonalNumber("19800212-1234"));
            Assert.IsTrue(new PersonalNumber("800212") != new PersonalNumber("900212"));
        }
        [TestMethod]
        public void IsPlus100YearsOld()
        {
            Assert.IsFalse(new PersonalNumber("800213").IsPlus100YearsOld);
            Assert.IsFalse(new PersonalNumber("800213-0123").IsPlus100YearsOld);
            Assert.IsTrue(new PersonalNumber("800213+0123").IsPlus100YearsOld);
        }
    }
