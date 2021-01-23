    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public interface IViewLoginPanel
    {
        IList<Person> Staff { get; set; }
    }
    public class PresenterLoginPanel {
        private IViewLoginPanel _iViewLoginPanel;
        public PresenterLoginPanel(IViewLoginPanel panel) 
        { 
            _iViewLoginPanel = panel;
            SomeFunction();
        }
        public void SomeFunction() 
        {
            List<Person> loginStaff = new List<Person>(); 
            loginStaff.Add(new Person{FirstName = "John", LastName = "Doe"});
            _iViewLoginPanel.Staff = loginStaff;
        }
        public IViewLoginPanel ViewLoginPanel
        {
            get { return _iViewLoginPanel; }
        }
    }
    [TestFixture]
    public class PresenterLoginPanelTests
    {
        [Test]
        public void When_The_Presenter_Is_Created_Then_All_CP_Staff_Is_Added_To_Dropdown()
        {
            var _mockViewLoginPanel = new Mock<IViewLoginPanel>(MockBehavior.Strict);
            _mockViewLoginPanel.SetupAllProperties();
            PresenterLoginPanel target = new PresenterLoginPanel(_mockViewLoginPanel.Object);
            _mockViewLoginPanel.VerifySet(x => x.Staff = It.IsAny<List<Person>>());
            Assert.AreEqual(5, _mockViewLoginPanel.Object.Staff.Count);
        }
   
    }
