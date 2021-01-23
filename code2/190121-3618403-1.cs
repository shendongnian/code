    using Moq;
    [TestClass]
    public class TestClass {
	  Mock<IStackTagzContext> m_EntitiesMock = new Mock<IStackTagzContext>();
	  [TestMethod()]
	  public void GetShouldFilterBySite() {
	  	  QuestionsRepository target = new QuestionsRepository(m_EntitiesMock.Object);
		  m_EntitiesMock.Setup(e=>e.Questions).Returns(new [] {
			new Question{Site = "site1", QuestionId = 1, Date = new DateTime(2010, 06,23)},
		  }.AsQueryable());
	  }
    }
