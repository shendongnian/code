        [Test]
        public Test()
        {
            var homeController = new HomeController();
            var result = homeController.About() as ViewResult();
            Assert.IsInstanceOf(typeof(MyViewModel),result.ViewData.Model);
            var myModel = result.ViewData.Model as MyViewModel;
            Assert.That(myModel.Name,Is.EqualTo("Hello World")  );
        }
